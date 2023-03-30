namespace Spoon.NuGet.SecureRemotePassword.Application.Me.Email.SetAsPrimaryEmail
{
    using Administration.SetUserEmailAsPrimary;
    using Domain.Entities;
    using Domain.Repositories;
    using EitherCore.Enums;
    using EitherCore.Helpers;
    using Helpers;
    using MediatR;
    using Spoon.NuGet.Core;
    using Spoon.NuGet.EitherCore;

    /// <summary>
    ///     Class ProductCreateQueryHandler. This class cannot be inherited.
    /// </summary>
    public sealed class MeEmailSetAsPrimaryCommandHandler : IRequestHandler<MeEmailSetAsPrimaryCommand, Either<MeEmailSetAsPrimaryCommandResult>>
    {
        private readonly ISecureRemotePasswordRepository _repository;

        /// <summary>
        /// </summary>
        /// <param name="writeRepository"></param>
        /// <param name="mockbleGuidGenerator"></param>
        /// <param name="repository"></param>
        public MeEmailSetAsPrimaryCommandHandler(ISecureRemotePasswordRepository repository)
        {
            this._repository = repository;
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
        public async Task<Either<MeEmailSetAsPrimaryCommandResult>> Handle(
            MeEmailSetAsPrimaryCommand request,
            CancellationToken cancellationToken)
        {
            var existingUserEmails = await this._repository.UserEmails.GetAllAsync(new MeEmailSetAsPrimaryCommandSpecification(request.UserId), cancellationToken);
            

            var newPrimaryUserEmail = existingUserEmails.FirstOrDefault(x => x.EmailId == request.EmailId);
            
            if (newPrimaryUserEmail == null)
            {
                return EitherHelper<MeEmailSetAsPrimaryCommandResult>.EntityNotFound(typeof(UserEmail));
            }
            
            foreach (var userEmail in existingUserEmails)
            {
                userEmail.IsPrimary = 0; 
            }
            
            existingUserEmails.First(x => x.EmailId == request.EmailId).IsPrimary = 1;
            
            await this._repository.SaveChangesAsync(cancellationToken);
            
            return new Either<MeEmailSetAsPrimaryCommandResult>(new MeEmailSetAsPrimaryCommandResult());
        }
    }
}