namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.RemoveUserEmail
{
    using Domain.Entities;
    using Domain.Repositories;
    using EitherCore.Enums;
    using EitherCore.Helpers;
    using GetUser;
    using MediatR;
    using Spoon.NuGet.Core;
    using Spoon.NuGet.EitherCore;

    /// <summary>
    ///     Class ProductCreateQueryHandler. This class cannot be inherited.
    /// </summary>
    public sealed class AdministrationRemoveUserEmailCommandHandler : IRequestHandler<AdministrationRemoveUserEmailCommand, Either<AdministrationRemoveUserEmailCommandResult>>
    {
        private readonly ISecureRemotePasswordRepository _repository;

        /// <summary>
        /// </summary>
        /// <param name="writeRepository"></param>
        /// <param name="mockbleGuidGenerator"></param>
        public AdministrationRemoveUserEmailCommandHandler(ISecureRemotePasswordRepository repository)
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
        public async Task<Either<AdministrationRemoveUserEmailCommandResult>> Handle(
            AdministrationRemoveUserEmailCommand request,
            CancellationToken cancellationToken)
        {
            var existingUserEmail = await this._repository.UserEmails.GetAsync(new GetUserEmailSpecification(request.UserId, request.EmailId), cancellationToken);
            
            if(existingUserEmail == null)
                return EitherHelper<AdministrationRemoveUserEmailCommandResult>.EntityNotFound(typeof(UserEmail));

            if (existingUserEmail.IsPrimary == 1)
            {
                return EitherHelper<AdministrationRemoveUserEmailCommandResult>.Create("BadPermissions_CannotRemovePrimary",BaseHttpStatusCodes.Status423Locked);
            }
            
            
            this._repository.UserEmails.Remove(existingUserEmail);
            
            await this._repository.SaveChangesAsync(cancellationToken);
            
            return new Either<AdministrationRemoveUserEmailCommandResult>(new AdministrationRemoveUserEmailCommandResult());
        }
    }
}