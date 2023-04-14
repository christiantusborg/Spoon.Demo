namespace Spoon.NuGet.SecureRemotePassword.Application.Users.UserForgotPasswordRecoverByRecoveryCodeChallengeGet;

using Core.Application;
using Domain.Entities;
using Domain.Repositories;
using EitherCore;
using EitherCore.Helpers;
using Helpers;
using MediatR;
using Services;
using SharedSpecification;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class UserForgotPasswordRecoverByRecoveryCodeChallengeGetCommandHandler : IRequestHandler<UserForgotPasswordRecoverByRecoveryCodeChallengeGetCommand,
    Either<UserForgotPasswordRecoverByRecoveryCodeChallengeGetCommandResult>>
{
    private readonly ISecureRemotePasswordRepository _repository;
    private readonly IEncryptionService _encryptionService;
    private readonly ISecureRemotePasswordService _secureRemotePasswordService;

    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="encryptionService"></param>
    /// <param name="secureRemotePasswordService"></param>
    public UserForgotPasswordRecoverByRecoveryCodeChallengeGetCommandHandler(ISecureRemotePasswordRepository repository,
        IEncryptionService encryptionService,
        ISecureRemotePasswordService secureRemotePasswordService)
    {
        this._repository = repository;
        this._encryptionService = encryptionService;
        this._secureRemotePasswordService = secureRemotePasswordService;
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
    public async Task<Either<UserForgotPasswordRecoverByRecoveryCodeChallengeGetCommandResult>> Handle(
        UserForgotPasswordRecoverByRecoveryCodeChallengeGetCommand request,
        CancellationToken cancellationToken)
    {
        var usernameExists = await this._repository.Users.GetAsync(new GetUserByHashSpecification(request.UsernameHashed), cancellationToken);

        if (usernameExists == null)
            return EitherHelper<UserForgotPasswordRecoverByRecoveryCodeChallengeGetCommandResult>.EntityNotFound(typeof(User));

        var existingUserSecureRemotePasswordLogins =
            await this._repository.SecureRemotePasswordByRecoveryCodes.GetAsync(new DefaultGetSpecification<SecureRemotePasswordByRecoveryCode>(usernameExists.UserId), cancellationToken);

        if (existingUserSecureRemotePasswordLogins == null)
            return EitherHelper<UserForgotPasswordRecoverByRecoveryCodeChallengeGetCommandResult>.EntityNotFound(typeof(SecureRemotePasswordByRecoveryCode));

        var saltDecrypted = this._encryptionService.Decrypt(existingUserSecureRemotePasswordLogins.SaltEncrypted);

        var verifierDecrypted = this._encryptionService.Decrypt(existingUserSecureRemotePasswordLogins.VerifierEncrypted);

        var challenge = this._secureRemotePasswordService.GenerateChallenge(usernameExists.UserId, verifierDecrypted);

        var result = new UserForgotPasswordRecoverByRecoveryCodeChallengeGetCommandResult
        {
            Challenge = challenge,
            UserId = existingUserSecureRemotePasswordLogins.UserId,
            Salt = saltDecrypted,
        };
        return new Either<UserForgotPasswordRecoverByRecoveryCodeChallengeGetCommandResult>(result);
    }
}