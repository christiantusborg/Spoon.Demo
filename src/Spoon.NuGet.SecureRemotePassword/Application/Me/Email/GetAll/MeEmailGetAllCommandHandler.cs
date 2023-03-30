namespace Spoon.NuGet.SecureRemotePassword.Application.Me.Email.GetAll
{
    using Administration.RemoveUserEmail;
    using Domain.Entities;
    using Domain.Repositories;
    using EitherCore.Helpers;
    using Get;
    using Helpers;
    using MediatR;
    using Spoon.NuGet.Core;
    using Spoon.NuGet.EitherCore;

    /// <summary>
    ///     Class ProductCreateQueryHandler. This class cannot be inherited.
    /// </summary>
    public sealed class MeEmailGetAllCommandHandler : IRequestHandler<MeEmailGetAllCommand, Either<MeEmailGetAllCommandResult>>
    {
        private readonly ISecureRemotePasswordRepository _repository;
        private readonly IEncryptionService _encryptionService;


        /// <summary>
        /// </summary>
        /// <param name="writeRepository"></param>
        /// <param name="mockbleGuidGenerator"></param>
        public MeEmailGetAllCommandHandler(ISecureRemotePasswordRepository repository,IEncryptionService encryptionService)
        {
            this._repository = repository;
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
        public async Task<Either<MeEmailGetAllCommandResult>> Handle(
            MeEmailGetAllCommand request,
            CancellationToken cancellationToken)
        {
            var existingUserEmail = await this._repository.UserEmails.GetAllAsync(new MeEmailGetAllCommandSpecification(request.UserId),cancellationToken);
            
            if(existingUserEmail.Count == 0)
                return EitherHelper<MeEmailGetAllCommandResult>.EntityNotFound(typeof(UserEmail));


            var result = new MeEmailGetAllCommandResult
            {
                UserId = request.UserId,
                Emails = this.GetEmailsDecrypted(existingUserEmail),
            };

            return new Either<MeEmailGetAllCommandResult>(result);


        }
        
        private List<MeEmailGetAllOneEmailCommandResult> GetEmailsDecrypted(List<UserEmail> userEmail)
        {
            var result =userEmail.Select(email => new MeEmailGetAllOneEmailCommandResult
                {
                    EmailId = email.EmailId,
                    Email = this._encryptionService.Decrypt(email.EmailAddressEncrypted),
                    IsPrimary = email.IsPrimary == 1,
                })
                .ToList();
            
            return result;
        }
    }
}