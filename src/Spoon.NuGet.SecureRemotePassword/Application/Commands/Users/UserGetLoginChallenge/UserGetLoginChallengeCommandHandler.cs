namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Users.UserGetLoginChallenge;

using Core.Application;
using Domain.Entities;
using Domain.Repositories;
using Helpers;
using Services;
using SharedSpecification;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class UserGetLoginChallengeCommandHandler : IRequestHandler<UserGetLoginChallengeCommand, Either<UserGetLoginChallengeCommandResult>>
{
    private readonly ISecureRemotePasswordRepository _repository;
    private readonly ISecureRemotePasswordService _secureRemotePasswordService;
    private readonly IEncryptionService _encryptionService;

    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="secureRemotePasswordService"></param>
    /// <param name="encryptionService"></param>
    public UserGetLoginChallengeCommandHandler(ISecureRemotePasswordRepository repository, ISecureRemotePasswordService secureRemotePasswordService, IEncryptionService encryptionService)
    {
        this._repository = repository;
        this._secureRemotePasswordService = secureRemotePasswordService;
        this._encryptionService = encryptionService;
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
    public async Task<Either<UserGetLoginChallengeCommandResult>> Handle(
        UserGetLoginChallengeCommand request,
        CancellationToken cancellationToken)
    {
        var existingUser = await this._repository.Users.GetAsync(new GetUserByHashSpecification(request.UsernameHashed), cancellationToken);

        if (existingUser == null)
            return EitherHelper<UserGetLoginChallengeCommandResult>.EntityNotFound(typeof(SecureRemotePasswordLogin));


        var existingSecureRemotePasswordLogin = await this._repository.SecureRemotePasswordLogins.GetAsync(new DefaultGetSpecification<SecureRemotePasswordLogin>(existingUser.UserId), cancellationToken);

        if (existingSecureRemotePasswordLogin == null)
            return EitherHelper<UserGetLoginChallengeCommandResult>.EntityNotFound(typeof(SecureRemotePasswordLogin));


        var verifierDecrypted = this._encryptionService.Decrypt(existingSecureRemotePasswordLogin.VerifierEncrypted);

        var challenge = this._secureRemotePasswordService.GenerateChallenge(existingUser.UserId, verifierDecrypted);

        var saltDecrypted = this._encryptionService.Decrypt(existingSecureRemotePasswordLogin.SaltEncrypted);

        var result = new UserGetLoginChallengeCommandResult
        {
            Challenge = challenge,
            UserId = existingUser.UserId,
            Salt = saltDecrypted,
        };
        return new Either<UserGetLoginChallengeCommandResult>(result);
    }
}