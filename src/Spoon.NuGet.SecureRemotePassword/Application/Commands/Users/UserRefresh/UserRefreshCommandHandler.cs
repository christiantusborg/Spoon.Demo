namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Users.UserRefresh;

using Administration.GetUser;
using Core;
using Core.Application;
using Domain.Entities;
using Domain.Repositories;
using Helpers;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class UserRefreshCommandHandler : IRequestHandler<UserRefreshCommand, Either<UserRefreshCommandResult>>
{
    private readonly ISecureRemotePasswordRepository _repository;
    private readonly IIdentityGenerationService _identityGenerationService;
    private readonly IHashService _hashService;
    private readonly IMockbleDateTime _mockbleDateTime;
    private readonly ITokenService _tokenService;


    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="identityGenerationService"></param>
    /// <param name="hashService"></param>
    /// <param name="mockbleDateTime"></param>
    /// <param name="tokenService"></param>
    public UserRefreshCommandHandler(ISecureRemotePasswordRepository repository,
        IIdentityGenerationService identityGenerationService,
        IHashService hashService,
        IMockbleDateTime mockbleDateTime,
        ITokenService tokenService)
    {
        this._repository = repository;
        this._identityGenerationService = identityGenerationService;
        this._hashService = hashService;
        this._mockbleDateTime = mockbleDateTime;
        this._tokenService = tokenService;
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
    public async Task<Either<UserRefreshCommandResult>> Handle(
        UserRefreshCommand request,
        CancellationToken cancellationToken)
    {
        var expirationTime = this._tokenService.GetTokenLifetime(); // this._configuration.GetValue<int?>("SecureRemotePassword:Session:RefreshToken:ExpirationTimeInMinutes") ?? 30;

        var user = await this._repository.Users.GetAsync(new GetUserSpecification(request.UserId), cancellationToken);

        if (user is null)
            return EitherHelper<UserRefreshCommandResult>.EntityNotFound(typeof(User));

        var emailEncrypted = user.UserEmails.FirstOrDefault(x => x.IsPrimary == 1);

        if (emailEncrypted is null)
            return EitherHelper<UserRefreshCommandResult>.EntityNotFound(typeof(UserEmail));

        var originalRefreshToken = this._identityGenerationService.GenerateRefreshToken(request.UserId, emailEncrypted.EmailId, request.Iat);

        var originalRefreshTokenHash = this._hashService.Hash(originalRefreshToken);

        var session = await this._repository.Sessions.GetAsync(new DefaultGetSpecification<Session>(request.SessionId), cancellationToken);

        if (session is null)
            return EitherHelper<UserRefreshCommandResult>.Create("Session", BaseHttpStatusCodes.Status498InvalidToken);

        if (originalRefreshToken != request.RefreshToken && originalRefreshTokenHash != request.RefreshTokenVerifier)
            return EitherHelper<UserRefreshCommandResult>.Create("RefreshTokenIsInvalid", BaseHttpStatusCodes.Status498InvalidToken);

        var now = this._mockbleDateTime.UtcNow;
        var nowOffset = new DateTimeOffset(now, TimeSpan.Zero);
        var unixTimestamp = nowOffset.ToUnixTimeSeconds();
        var expireAt = now.AddMinutes(expirationTime);


        var nextRefreshToken = this._identityGenerationService.GenerateRefreshToken(request.UserId, emailEncrypted.EmailId, unixTimestamp);

        var refreshTokenVerifierHash = this._hashService.Hash(nextRefreshToken);

        var jwt = this._identityGenerationService.GenerateToken(request.UserId, emailEncrypted.EmailId, session.SessionId, refreshTokenVerifierHash, unixTimestamp, expireAt);


        await this._repository.SaveChangesAsync(cancellationToken);

        var result = new UserRefreshCommandResult
        {
            AccessToken = jwt,
            RefreshToken = nextRefreshToken,
            ExpiresIn = expirationTime,
        };

        return new Either<UserRefreshCommandResult>(result);
    }
}