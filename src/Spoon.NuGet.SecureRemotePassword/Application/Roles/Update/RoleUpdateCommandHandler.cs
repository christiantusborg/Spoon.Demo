namespace Spoon.NuGet.SecureRemotePassword.Application.Roles.Update
{
    using Core.Application;
    using Create;
    using Domain.Entities;
    using Domain.Repositories;
    using EitherCore.Helpers;
    using MediatR;
    using Spoon.NuGet.Core;
    using Spoon.NuGet.EitherCore;

    /// <summary>
    ///     Class ProductCreateQueryHandler. This class cannot be inherited.
    /// </summary>
    public sealed class RoleUpdateCommandHandler : IRequestHandler<RoleUpdateCommand, Either<RoleUpdateCommandResult>>
    {
        private readonly ISecureRemotePasswordRepository _repository;

        /// <summary>
        /// </summary>
        /// <param name="writeRepository"></param>
        /// <param name="mockbleGuidGenerator"></param>
        public RoleUpdateCommandHandler(ISecureRemotePasswordRepository repository)
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
        public async Task<Either<RoleUpdateCommandResult>> Handle(
            RoleUpdateCommand request,
            CancellationToken cancellationToken)
        {
            // Check if a role with the specified name already exists in the repository.
            var existingRole = await this._repository.Roles.GetAsync(new DefaultGetSpecification<Role>(request.RoleId), cancellationToken);

            // If a role with the specified name already exists, return an error message.
            if (existingRole == null)
                return EitherHelper<RoleUpdateCommandResult>.EntityAlreadyExists(typeof(Role));

            existingRole.Name = request.Name;

            // Save changes to the repository.
            await this._repository.SaveChangesAsync(cancellationToken);



            // Return an Either instance with the RoleCreateCommandResult.
            return new Either<RoleUpdateCommandResult>(new RoleUpdateCommandResult());
        }
    }
}