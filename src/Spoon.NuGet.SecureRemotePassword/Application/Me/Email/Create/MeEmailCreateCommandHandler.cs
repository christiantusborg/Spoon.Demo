namespace Spoon.NuGet.SecureRemotePassword.Application.Me.Email.Create
{
    using Administration.AddUserEmail;
    using Core.Application;
    using Domain.Entities;
    using Domain.Repositories;
    using EitherCore.Helpers;
    using Helpers;
    using MediatR;
    using SharedSpecification;
    using Spoon.NuGet.Core;
    using Spoon.NuGet.EitherCore;

    /// <summary>
    ///     Class ProductCreateQueryHandler. This class cannot be inherited.
    /// </summary>
    public sealed class MeEmailCreateCommandHandler : IRequestHandler<MeEmailCreateCommand, Either<MeEmailCreateCommandResult>>
    {
        private readonly IMockbleDateTime _mockbleDateTime;
        private readonly ISecureRemotePasswordRepository _repository;

        private readonly IMockbleGuidGenerator _mockbleGuidGenerator;
        private readonly IEncryptionService _encryptionService;
        private readonly IHashService _hashService;

        /// <summary>
        /// </summary>
        /// <param name="writeRepository"></param>
        /// <param name="repository"></param>
        /// <param name="mockbleGuidGenerator"></param>
        public MeEmailCreateCommandHandler(IMockbleDateTime mockbleDateTime, ISecureRemotePasswordRepository repository, IMockbleGuidGenerator mockbleGuidGenerator,
            IEncryptionService encryptionService,
            IHashService hashService)
        {
            this._mockbleDateTime = mockbleDateTime;
            this._repository = repository;
            this._mockbleGuidGenerator = mockbleGuidGenerator;
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
        public async Task<Either<MeEmailCreateCommandResult>> Handle(
            MeEmailCreateCommand request,
            CancellationToken cancellationToken)
        {
            var user = await this._repository.Users.GetAsync(new DefaultGetSpecification<User>(request.UserId), cancellationToken);
            if (user == null)
                return EitherHelper<MeEmailCreateCommandResult>.EntityNotFound(typeof(User));
        
            
            var emailAddressHash = this._hashService.Hash(request.Email);
            
            var emailExists = await this._repository.UserEmails.GetAsync(new GetEmailByHashSpecification(emailAddressHash), cancellationToken);
            if(emailExists != null)
                return EitherHelper<MeEmailCreateCommandResult>.EntityAlreadyExists(typeof(UserEmail));

            var emailId = this._mockbleGuidGenerator.NewGuid();
            var emailAddressEncrypted = this._encryptionService.Encrypt(request.Email);

            var userEmail = new UserEmail
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
            
            this._repository.UserEmails.Add(userEmail);
            await this._repository.SaveChangesAsync(cancellationToken);
            
            return new Either<MeEmailCreateCommandResult>(new MeEmailCreateCommandResult
            {
                EmailId = emailId,
            });
        }
    }
}