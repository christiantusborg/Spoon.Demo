namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Users.UserForgotPasswordRecoverByEmailSet;

using Core;
using Core.Application;
using Domain.Entities;
using Domain.Repositories;
using Helpers;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class UserForgotPasswordRecoverByEmailSetCommandHandler : IRequestHandler<UserForgotPasswordRecoverByEmailSetCommand, Either<UserForgotPasswordRecoverByEmailSetCommandResult>>
{
    private readonly ISecureRemotePasswordRepository _repository;
    private readonly IMockbleDateTime _mockbleDateTime;
    private readonly IEncryptionService _encryptionService;


    /// <summary>
    /// </summary>
    /// <param name="mockbleDateTime"></param>
    /// <param name="repository"></param>
    /// <param name="encryptionService"></param>
    public UserForgotPasswordRecoverByEmailSetCommandHandler(ISecureRemotePasswordRepository repository,
        IMockbleDateTime mockbleDateTime,
        IEncryptionService encryptionService)
    {
        this._repository = repository;
        this._mockbleDateTime = mockbleDateTime;
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
    public async Task<Either<UserForgotPasswordRecoverByEmailSetCommandResult>> Handle(
        UserForgotPasswordRecoverByEmailSetCommand request,
        CancellationToken cancellationToken)
    {
        var existingEmailRecovery =
            await this._repository.SecureRemotePasswordByRecoveryEmails.GetAsync(new DefaultGetSpecification<SecureRemotePasswordByRecoveryEmail>(request.UserId), cancellationToken);

        if (existingEmailRecovery == null)
            return EitherHelper<UserForgotPasswordRecoverByEmailSetCommandResult>.EntityNotFound(typeof(SecureRemotePasswordByRecoveryEmail));

        if (existingEmailRecovery.RecoveryTokenHashed != request.RecoveryString)
            return EitherHelper<UserForgotPasswordRecoverByEmailSetCommandResult>.Create($"{nameof(UserForgotPasswordRecoverByEmailSetCommandResult)}_RecoveryTokenIsInvalid",
                BaseHttpStatusCodes.Status401Unauthorized);

        var existingUserSecureRemotePasswordLogins = await this._repository.SecureRemotePasswordLogins.GetAsync(new DefaultGetSpecification<SecureRemotePasswordLogin>(request.UserId), cancellationToken);
        if (existingUserSecureRemotePasswordLogins == null)
            return EitherHelper<UserForgotPasswordRecoverByEmailSetCommandResult>.EntityNotFound(typeof(SecureRemotePasswordLogin));

        var existingUser = await this._repository.Users.GetAsync(new DefaultGetSpecification<User>(request.UserId), cancellationToken);

        if (existingUser == null)
            return EitherHelper<UserForgotPasswordRecoverByEmailSetCommandResult>.EntityNotFound(typeof(User));

        var verifierEncrypted = this._encryptionService.Encrypt(request.Verifier);
        existingUserSecureRemotePasswordLogins.VerifierEncrypted = verifierEncrypted;

        var saltEncrypted = this._encryptionService.Encrypt(request.Salt);
        existingUserSecureRemotePasswordLogins.SaltEncrypted = saltEncrypted;

        existingUser.LockoutEnd = null;
        existingUser.LockoutCount = 0;

        existingUserSecureRemotePasswordLogins.UpdatedAt = this._mockbleDateTime.UtcNow;

        return new Either<UserForgotPasswordRecoverByEmailSetCommandResult>(new UserForgotPasswordRecoverByEmailSetCommandResult());
    }
}