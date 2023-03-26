namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.AddUserEmail
{
    using Core.Application;
    using Domain.Entities;
    using Domain.Repositories;
    using Helpers;
    using MediatR;
    using SharedSpecification;
    using Spoon.NuGet.Core;
    using Spoon.NuGet.EitherCore;
    using Spoon.NuGet.EitherCore.Helpers;
    
    /// <summary>
    ///     Class ProductCreateQueryHandler. This class cannot be inherited.
    /// </summary>
    public sealed class AdministrationAddUserEmailCommandHandler : IRequestHandler<AdministrationAddUserEmailCommand, Either<AdministrationAddUserEmailCommandResult>>
    {

        private readonly IMockbleGuidGenerator _mockbleGuidGenerator;
        private readonly IMockbleDateTime _mockbleDateTime;
        private readonly ISecureRemotePasswordRepository _repository;
        private readonly IEncryptionService _encryptionService;
        private readonly IHashService _hashService;


        /// <summary>
        /// </summary>
        /// <param name="writeRepository"></param>
        /// <param name="mockbleGuidGenerator"></param>
        public AdministrationAddUserEmailCommandHandler(IMockbleGuidGenerator mockbleGuidGenerator,
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
        public async Task<Either<AdministrationAddUserEmailCommandResult>> Handle(
            AdministrationAddUserEmailCommand request,
            CancellationToken cancellationToken)
        {
            var user = await this._repository.Users.Get(new DefaultGetSpecification<User>(request.UserId));
            if (user == null)
                return EitherHelper<AdministrationAddUserEmailCommandResult>.EntityNotFound(typeof(User));
        
            
            var emailAddressHash = this._hashService.Hash(request.Email);
            
            var emailExists = await this._repository.UserEmails.Get(new GetEmailByHashSpecification(emailAddressHash));
            if(emailExists != null)
                return EitherHelper<AdministrationAddUserEmailCommandResult>.EntityAlreadyExists(typeof(UserEmail));

            var emailId = this._mockbleGuidGenerator.NewGuid();
            var emailAddressEncrypted = this._encryptionService.Encrypt(request.Email);

            var email = new UserEmail
            {
                EmailId = emailId,
                IsPrimary = 0,
                UserId = request.UserId,
                EmailAddressEncrypted = emailAddressEncrypted,
                EmailAddressHash = emailAddressHash,
                EmailAddressVerifiedAt = null,
                CreatedAt = this._mockbleDateTime.UtcNow,
                UpdatedAt = this._mockbleDateTime.UtcNow,
                DeletedAt = null,
            };
            
            this._repository.UserEmails.Add(email);
            await this._repository.SaveChangesAsync(cancellationToken);
            
            return new Either<AdministrationAddUserEmailCommandResult>(new AdministrationAddUserEmailCommandResult
            {
                EmailId = emailId,
            });
        }
    }
}