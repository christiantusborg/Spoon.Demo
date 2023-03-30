namespace Spoon.NuGet.SecureRemotePassword.Application.Roles.GetAll
{
    using Domain.Entities;
    using Domain.Repositories;
    using EitherCore.Helpers;
    using Me.Email.GetAll;
    using MediatR;
    using Spoon.NuGet.Core;
    using Spoon.NuGet.EitherCore;

    /// <summary>
    ///     Class ProductCreateQueryHandler. This class cannot be inherited.
    /// </summary>
    public sealed class RoleGetAllCommandHandler : IRequestHandler<RoleGetAllCommand, Either<RoleGetAllCommandResult>>
    {
        private readonly ISecureRemotePasswordRepository _repository;

        /// <summary>
        /// </summary>
        /// <param name="repository"></param>
        public RoleGetAllCommandHandler(ISecureRemotePasswordRepository repository)
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
        public async Task<Either<RoleGetAllCommandResult>> Handle(
            RoleGetAllCommand request,
            CancellationToken cancellationToken)
        {
            List<Role> existingRoles = await this._repository.Roles.GetAllAsync(new RoleGetAllCommandSpecification(),cancellationToken);
            
            if(existingRoles.Count == 0)
                return EitherHelper<RoleGetAllCommandResult>.EntityNotFound(typeof(Role));


            var roleResult = existingRoles.Select(x => new RoleGetAllLRolesCommandResult
            {
                RoleId = x.RoleId,
                Name = x.Name,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                DeletedAt = x.DeletedAt,
            }).ToList();
            
            var result = new RoleGetAllCommandResult
            {
                Roles   = roleResult,
            };

            return new Either<RoleGetAllCommandResult>(result);
        }
    }
}