namespace Spoon.NuGet.SecureRemotePassword.Application.Roles.DeletePermanent
{
    using MediatR;
    using Spoon.NuGet.Core.Application;
    using Spoon.NuGet.EitherCore;
    using Spoon.NuGet.EitherCore.Enums;
    using Spoon.NuGet.EitherCore.Helpers;
    using Spoon.NuGet.SecureRemotePassword.Domain.Entities;
    using Spoon.NuGet.SecureRemotePassword.Domain.Repositories;

    /// <summary>
    ///     Class ProductCreateQueryHandler. This class cannot be inherited.
    /// </summary>
    public sealed class RoleDeletePermanentCommandHandler : IRequestHandler<RoleDeletePermanentCommand, Either<RoleDeletePermanentCommandResult>>
    {
        private readonly ISecureRemotePasswordRepository _repository;


        /// <summary>
        /// </summary>
        /// <param name="writeRepository"></param>
        /// <param name="mockbleGuidGenerator"></param>
        public RoleDeletePermanentCommandHandler(ISecureRemotePasswordRepository repository)
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
        public async Task<Either<RoleDeletePermanentCommandResult>> Handle(
            RoleDeletePermanentCommand request,
            CancellationToken cancellationToken)
        {
            var existingRole = await this._repository.Roles.GetAsync(new DefaultGetSpecification<Domain.Entities.Role>(request.RoleId), cancellationToken);
            
            if (existingRole == null)
                return EitherHelper<RoleDeletePermanentCommandResult>.EntityNotFound(typeof(User));

            if (existingRole.Name == "root")
                return EitherHelper<RoleDeletePermanentCommandResult>.Create("CannotNotDeleteTheRootRole",BaseHttpStatusCodes.Status403Forbidden);
            
            
            this._repository.Roles.Remove(existingRole);

            await this._repository.SaveChangesAsync(cancellationToken);
            
            return new Either<RoleDeletePermanentCommandResult>(new RoleDeletePermanentCommandResult());
        }
    }
}