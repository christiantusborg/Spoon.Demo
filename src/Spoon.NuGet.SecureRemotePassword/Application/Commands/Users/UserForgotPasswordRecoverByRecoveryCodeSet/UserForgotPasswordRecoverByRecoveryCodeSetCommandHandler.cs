namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Users.UserForgotPasswordRecoverByRecoveryCodeSet;

using Core;
using Core.Application;
using Domain.Entities;
using Domain.Repositories;
using Helpers;
using SharedSpecification;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class UserForgotPasswordRecoverByRecoveryCodeSetCommandHandler : IRequestHandler<UserForgotPasswordRecoverByRecoveryCodeSetCommand,
    Either<UserForgotPasswordRecoverByRecoverySetChallengeGetCommandResult>>
{
    private readonly ISecureRemotePasswordRepository _repository;
    private readonly IEncryptionService _encryptionService;
    private readonly IMockbleDateTime _mockbleDateTime;

    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="encryptionService"></param>
    /// <param name="mockbleDateTime"></param>
    public UserForgotPasswordRecoverByRecoveryCodeSetCommandHandler(ISecureRemotePasswordRepository repository, IEncryptionService encryptionService, IMockbleDateTime mockbleDateTime)
    {
        this._repository = repository;
        this._encryptionService = encryptionService;
        this._mockbleDateTime = mockbleDateTime;
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
    public async Task<Either<UserForgotPasswordRecoverByRecoverySetChallengeGetCommandResult>> Handle(
        UserForgotPasswordRecoverByRecoveryCodeSetCommand request,
        CancellationToken cancellationToken)
    {
        var existingUser = await this._repository.Users.GetAsync(new GetUserByHashSpecification(request.UsernameHashed), cancellationToken);
        
        if(existingUser == null)
            return EitherHelper<UserForgotPasswordRecoverByRecoverySetChallengeGetCommandResult>.EntityNotFound(typeof(User));
        
        var existingUserSecureRemotePasswordLogins = await this._repository.SecureRemotePasswordLogins.GetAsync(new DefaultGetSpecification<SecureRemotePasswordLogin>(existingUser.UserId), cancellationToken);

        if (existingUserSecureRemotePasswordLogins == null)
            return EitherHelper<UserForgotPasswordRecoverByRecoverySetChallengeGetCommandResult>.EntityNotFound(typeof(SecureRemotePasswordLogin));

        var verifierEncrypted = this._encryptionService.Encrypt(request.Verifier);
        var saltEncrypted = this._encryptionService.Encrypt(request.Salt);

        existingUserSecureRemotePasswordLogins.SaltEncrypted = saltEncrypted;
        existingUserSecureRemotePasswordLogins.VerifierEncrypted = verifierEncrypted;
        existingUserSecureRemotePasswordLogins.UpdatedAt = this._mockbleDateTime.UtcNow;

        return new Either<UserForgotPasswordRecoverByRecoverySetChallengeGetCommandResult>(new UserForgotPasswordRecoverByRecoverySetChallengeGetCommandResult());
    }
}