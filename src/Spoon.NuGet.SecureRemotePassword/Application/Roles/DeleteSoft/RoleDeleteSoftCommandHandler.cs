namespace Spoon.NuGet.SecureRemotePassword.Application.Roles.DeleteSoft
{
    using MediatR;
    using Spoon.NuGet.Core;
    using Spoon.NuGet.Core.Application;
    using Spoon.NuGet.EitherCore;
    using Spoon.NuGet.EitherCore.Enums;
    using Spoon.NuGet.EitherCore.Helpers;
    using Spoon.NuGet.SecureRemotePassword.Domain.Entities;
    using Spoon.NuGet.SecureRemotePassword.Domain.Repositories;

    /// <summary>
    ///     Class ProductCreateQueryHandler. This class cannot be inherited.
    /// </summary>
    public sealed class RoleDeleteSoftCommandHandler : IRequestHandler<RoleDeleteSoftCommand, Either<RoleDeleteSoftCommandResult>>
    {
        private readonly ISecureRemotePasswordRepository _repository;
        private readonly IMockbleDateTime _mockbleDateTime;

        /// <summary>
        /// </summary>
        /// <param name="writeRepository"></param>
        /// <param name="mockbleGuidGenerator"></param>
        public RoleDeleteSoftCommandHandler(ISecureRemotePasswordRepository repository, IMockbleDateTime mockbleDateTime)
        {
            this._repository = repository;
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
        public async Task<Either<RoleDeleteSoftCommandResult>> Handle(
            RoleDeleteSoftCommand request,
            CancellationToken cancellationToken)
        {
            var existingRole = await this._repository.Roles.GetAsync(new DefaultGetSpecification<Domain.Entities.Role>(request.RoleId), cancellationToken);
            
            if (existingRole == null)
                return EitherHelper<RoleDeleteSoftCommandResult>.EntityNotFound(typeof(User));

            if (existingRole.Name == "root")
                return EitherHelper<RoleDeleteSoftCommandResult>.Create("CannotNotDeleteTheRootRole",BaseHttpStatusCodes.Status403Forbidden);
            
            existingRole.DeletedAt = this._mockbleDateTime.UtcNow;
            existingRole.UpdatedAt = this._mockbleDateTime.UtcNow;

            await this._repository.SaveChangesAsync(cancellationToken);
            
            return new Either<RoleDeleteSoftCommandResult>(new RoleDeleteSoftCommandResult());
        }
    }
}