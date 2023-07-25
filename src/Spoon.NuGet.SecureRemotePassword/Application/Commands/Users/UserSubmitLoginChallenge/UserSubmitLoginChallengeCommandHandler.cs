namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Users.UserSubmitLoginChallenge;

using Administration.GetUser;
using Core;
using Domain.Entities;
using Domain.Repositories;
using Helpers;
using Microsoft.Extensions.Configuration;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class UserSubmitLoginChallengeCommandHandler : IRequestHandler<UserSubmitLoginChallengeCommand, Either<UserSubmitLoginChallengeCommandResult>>
{
    private readonly ISecureRemotePasswordRepository _repository;
    private readonly IIdentityGenerationService _identityGenerationService;
    private readonly IMockbleDateTime _mockbleDateTime;
    private readonly IHashService _hashService;
    private readonly IMockbleGuidGenerator _mockbleGuidGenerator;
    private readonly IEncryptionService _encryptionService;
    private readonly IConfiguration _configuration;

    /// <summary>
    ///     Initializes a new instance of the <see cref="UserSubmitLoginChallengeCommandHandler" /> class.
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="identityGenerationService"></param>
    /// <param name="mockbleDateTime"></param>
    /// <param name="hashService"></param>
    /// <param name="mockbleGuidGenerator"></param>
    /// <param name="encryptionService"></param>
    /// <param name="configuration"></param>
    public UserSubmitLoginChallengeCommandHandler(ISecureRemotePasswordRepository repository,
        IIdentityGenerationService identityGenerationService,
        IMockbleDateTime mockbleDateTime,
        IHashService hashService,
        IMockbleGuidGenerator mockbleGuidGenerator,
        IEncryptionService encryptionService,
        IConfiguration configuration)
    {
        this._repository = repository;
        this._identityGenerationService = identityGenerationService;
        this._mockbleDateTime = mockbleDateTime;
        this._hashService = hashService;
        this._mockbleGuidGenerator = mockbleGuidGenerator;
        this._encryptionService = encryptionService;
        this._configuration = configuration;
    }

    /// <summary>
    ///     Handles the specified request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="cancellationToken">
    ///     The cancellation token that can be used by other objects or threads to receive notice
    ///     of cancellation.
    /// </param>
    /// <returns>Task&lt;Either&lt;ProductCreateQueryResult&gt;&gt;.</returns>
    public async Task<Either<UserSubmitLoginChallengeCommandResult>> Handle(
        UserSubmitLoginChallengeCommand request,
        CancellationToken cancellationToken)
    {
        var expirationTime = this._configuration.GetValue<int?>("SecureRemotePassword:Session:RefreshToken:ExpirationTimeInMinutes") ?? 30;

        var user = await this._repository.Users.GetAsync(new GetUserSpecification(request.UserId), cancellationToken);

        if (user is null)
            return EitherHelper<UserSubmitLoginChallengeCommandResult>.EntityNotFound(typeof(User));

        var emailEncrypted = user.UserEmails.FirstOrDefault(x => x.IsPrimary == 1);

        if (emailEncrypted is null)
            return EitherHelper<UserSubmitLoginChallengeCommandResult>.EntityNotFound(typeof(UserEmail));

        var now = this._mockbleDateTime.UtcNow;
        var nowOffset = new DateTimeOffset(now, TimeSpan.Zero);
        var unixTimestamp = nowOffset.ToUnixTimeSeconds();
        var expireAt = now.AddMinutes(expirationTime);

        var nextRefreshToken = this._identityGenerationService.GenerateRefreshToken(request.UserId, emailEncrypted.EmailId, unixTimestamp);

        var refreshTokenVerifierHash = this._hashService.Hash(nextRefreshToken);

        var sessionId = this._mockbleGuidGenerator.NewId();

        var session = new Session
        {
            UserId = request.UserId,
            ActionAt = this._mockbleDateTime.UtcNow,
            CreatedAt = this._mockbleDateTime.UtcNow,
            SessionId = sessionId,
            UpdatedAt = this._mockbleDateTime.UtcNow,
            IpAddressEncrypted = this._encryptionService.Encrypt(request.IpAddress),
            RefreshTokenHashed = refreshTokenVerifierHash,
            SessionExpiresAt = expireAt,
            UserAgentEncrypted = this._encryptionService.Encrypt(request.UserAgent),
            RefreshTokenExpiresAt = expireAt,
        };

        this._repository.Sessions.Add(session);

        await this._repository.SaveChangesAsync(cancellationToken);

        var jwt = this._identityGenerationService.GenerateToken(request.UserId, emailEncrypted.EmailId, sessionId, refreshTokenVerifierHash, unixTimestamp, expireAt);

        var result = new UserSubmitLoginChallengeCommandResult
        {
            AccessToken = jwt,
            RefreshToken = nextRefreshToken,
            ExpiresIn = expirationTime,
        };

        return new Either<UserSubmitLoginChallengeCommandResult>(result);
    }
}