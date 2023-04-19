namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Users.UserRegister;

using Core;
using Core.Application;
using Domain.Entities;
using Domain.Repositories;
using Helpers;
using SharedSpecification;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand, Either<UserRegisterCommandResult>>
{
    private readonly IMockbleGuidGenerator _mockbleGuidGenerator;
    private readonly IMockbleDateTime _mockbleDateTime;
    private readonly ISecureRemotePasswordRepository _repository;
    private readonly IEncryptionService _encryptionService;
    private readonly IHashService _hashService;

    /// <summary>
    /// </summary>
    /// <param name="mockbleGuidGenerator"></param>
    /// <param name="encryptionService"></param>
    /// <param name="hashService"></param>
    /// <param name="mockbleDateTime"></param>
    /// <param name="repository"></param>
    public UserRegisterCommandHandler(IMockbleGuidGenerator mockbleGuidGenerator,
        IMockbleDateTime mockbleDateTime,
        ISecureRemotePasswordRepository repository,
        IEncryptionService encryptionService,
        IHashService hashService)
    {
        this._mockbleGuidGenerator = mockbleGuidGenerator;
        this._mockbleDateTime = mockbleDateTime;
        this._repository = repository;
        this._encryptionService = encryptionService;
        this._hashService = hashService;
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
    public async Task<Either<UserRegisterCommandResult>> Handle(
        UserRegisterCommand request,
        CancellationToken cancellationToken)
    {
        var emailAddressHash = this._hashService.Hash(request.Email);

        var emailExists = await this._repository.UserEmails.GetAsync(new GetEmailByHashSpecification(emailAddressHash), cancellationToken);
        if (emailExists != null)
            return EitherHelper<UserRegisterCommandResult>.EntityAlreadyExists(typeof(UserEmail));

        var usernameExists = await this._repository.Users.GetAsync(new GetUserByHashSpecification(request.UsernameHash), cancellationToken);
        if (usernameExists != null)
            return EitherHelper<UserRegisterCommandResult>.EntityAlreadyExists(typeof(User));


        var userId = this._mockbleGuidGenerator.NewGuid();

        var user = new User
        {
            UserId = userId,
            UsernameHash = request.UsernameHash,
            MustChangePassword = this._mockbleDateTime.UtcNow,
            DisabledAt = null,
            LastLogin = null,
            LockoutCount = 0,
            LockoutEnd = this._mockbleDateTime.UtcNow,
            CreatedAt = this._mockbleDateTime.UtcNow,
            UpdatedAt = this._mockbleDateTime.UtcNow,
            DeletedAt = null,
        };

        this._repository.Users.Add(user);
        await this._repository.SaveChangesAsync(cancellationToken);

        var emailId = this._mockbleGuidGenerator.NewGuid();
        var emailAddressEncrypted = this._encryptionService.Encrypt(request.Email);

        var email = new UserEmail
        {
            EmailId = emailId,
            IsPrimary = 1,
            UserId = userId,
            EmailAddressEncrypted = emailAddressEncrypted,
            EmailAddressHash = emailAddressHash,
            EmailAddressVerifiedAt = null,
            CreatedAt = this._mockbleDateTime.UtcNow,
            UpdatedAt = this._mockbleDateTime.UtcNow,
            DeletedAt = null,
        };


        this._repository.UserEmails.Add(email);
        await this._repository.SaveChangesAsync(cancellationToken);

        var recoveryToken = this._mockbleGuidGenerator.NewGuid();
        var recoveryTokenHash = this._hashService.Hash(recoveryToken.ToString());

        var byRecoveryEmail = new SecureRemotePasswordByRecoveryEmail
        {
            UserId = userId,
            RecoveryTokenHashed = recoveryTokenHash,
            CreatedAt = this._mockbleDateTime.UtcNow,
        };

        this._repository.SecureRemotePasswordByRecoveryEmails.Add(byRecoveryEmail);
        await this._repository.SaveChangesAsync(cancellationToken);

        var existingUserSecureRemotePasswordLogins = await this._repository.SecureRemotePasswordLogins.GetAsync(new DefaultGetSpecification<SecureRemotePasswordLogin>(userId), cancellationToken);

        if (existingUserSecureRemotePasswordLogins != null)
            return EitherHelper<UserRegisterCommandResult>.EntityAlreadyExists(typeof(SecureRemotePasswordLogin));

        var verifierEncrypted = this._encryptionService.Encrypt(request.Verifier);
        var saltEncrypted = this._encryptionService.Encrypt(request.Salt);

        var newSecureRemotePasswordLogin = new SecureRemotePasswordLogin
        {
            UserId = userId,
            SaltEncrypted = saltEncrypted,
            VerifierEncrypted = verifierEncrypted,
            UpdatedAt = this._mockbleDateTime.UtcNow,
        };

        this._repository.SecureRemotePasswordLogins.Add(newSecureRemotePasswordLogin);
        await this._repository.SaveChangesAsync(cancellationToken);

        var result = new Either<UserRegisterCommandResult>(new UserRegisterCommandResult());
        return result;
    }
}