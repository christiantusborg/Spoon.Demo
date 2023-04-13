namespace Spoon.NuGet.SecureRemotePassword.Application.UserRole.AddBulk
{
    using Core.Domain;
    using Domain.Entities;
    using Domain.Repositories;
    using EitherCore.Helpers;
    using MediatR;
    using SharedSpecification;
    using Spoon.NuGet.Core;
    using Spoon.NuGet.EitherCore;

    /// <summary>
    ///     Class ProductCreateQueryHandler. This class cannot be inherited.
    /// </summary>
    public sealed class UserRoleAddBulkCommandHandler : IRequestHandler<UserRoleAddBulkCommand, Either<UserRoleAddBulkCommandResult>>
    {
        private readonly ISecureRemotePasswordRepository _repository;

        /// <summary>
        /// </summary>
        /// <param name="repository"></param>
        public UserRoleAddBulkCommandHandler(ISecureRemotePasswordRepository repository)
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
        public async Task<Either<UserRoleAddBulkCommandResult>> Handle(
            UserRoleAddBulkCommand request,
            CancellationToken cancellationToken)
        {
            var roleFilters = new List<Filter>
            {
                new ()
                {
                    Operation = Operation.Equals,
                    Value = request.UserId,
                    PropertyName = "UserId",
                },
            };

            var existingUser = await this._repository.Users.GetAsync(new GetUserWithCRolesSpecification(roleFilters), cancellationToken);

            if (existingUser is null)
                return EitherHelper<UserRoleAddBulkCommandResult>.EntityNotFound(typeof(User));


            var filters = new List<Filter>
            {
                new ()
                {
                    Operation = Operation.Contains,
                    Value = request.Roles,
                    PropertyName = "RoleId",
                },
            };

            var existingRoles = await this._repository.Roles.SearchAsync(new GetWhereContainsRoleIdContainsSpecification(filters), cancellationToken);

            var newRoles = existingRoles.Except(existingUser.Roles!).ToList();


            foreach (var role in newRoles)
            {
                existingUser.Roles!.Add(role);
            }

            await this._repository.SaveChangesAsync(cancellationToken);

            return new Either<UserRoleAddBulkCommandResult>(new UserRoleAddBulkCommandResult());
        }
    }
}