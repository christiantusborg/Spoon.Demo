namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.CreateUser
{
    using AddUserEmail;
    using Domain.Entities;
    using Domain.Repositories;
    using EitherCore.Helpers;
    using Helpers;
    using MediatR;
    using SharedSpecification;
    using Spoon.NuGet.Core;
    using Spoon.NuGet.EitherCore;

    public sealed class AdministrationCreateUserCommandHandler : IRequestHandler<AdministrationCreateUserCommand, Either<AdministrationCreateUserCommandResult>>
    {

        private readonly IMockbleGuidGenerator _mockbleGuidGenerator;
        private readonly IMockbleDateTime _mockbleDateTime;
        private readonly ISecureRemotePasswordRepository _repository;
        private readonly IEncryptionService _encryptionService;
        private readonly IHashService _hashService;

        public AdministrationCreateUserCommandHandler(IMockbleGuidGenerator mockbleGuidGenerator,
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


        public async Task<Either<AdministrationCreateUserCommandResult>> Handle(
            AdministrationCreateUserCommand request,
            CancellationToken cancellationToken)
        {
            var emailAddressHash = this._hashService.Hash(request.Email);
            
            var emailExists = await this._repository.UserEmails.GetAsync(new GetEmailByHashSpecification(emailAddressHash), cancellationToken);
            if(emailExists != null)
                return EitherHelper<AdministrationCreateUserCommandResult>.EntityAlreadyExists(typeof(UserEmail));

            var userId = this._mockbleGuidGenerator.NewGuid();
            var user = new User
            {
                UserId = userId,
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
                EmailAddressHash = emailAddressHash,
                RecoveryTokenHash = recoveryTokenHash,
                CreatedAt = this._mockbleDateTime.UtcNow,

            };

            this._repository.SecureRemotePasswordByRecoveryEmails.Add(byRecoveryEmail);
            await this._repository.SaveChangesAsync(cancellationToken);
            
            
            return new Either<AdministrationCreateUserCommandResult>(new AdministrationCreateUserCommandResult
                {
                    UserId = userId,
                    RecoveryToken = recoveryToken,
                    EmailAddressHash = emailAddressHash,
                }
            );
        }
    }
}