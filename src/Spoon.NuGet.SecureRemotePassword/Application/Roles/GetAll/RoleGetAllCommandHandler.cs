namespace Spoon.NuGet.SecureRemotePassword.Application.Roles.GetAll
{
    using Core.Application;
    using Core.Domain;
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
    public sealed class RoleGetAllCommandHandler : IRequestHandler<RoleGetAllCommand, Either<BaseSearchCommandResult<RoleGetAllCommandResult>>>
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
        public async Task<Either<BaseSearchCommandResult<RoleGetAllCommandResult>>> Handle(
            RoleGetAllCommand request,
            CancellationToken cancellationToken)
        {
            var existingRoles = await this._repository.Roles.SearchAsync(new DefaultSearchSpecification<Role>(request.Filters.ToList(), new List<Sorting>(), request.Skip, request.Take, request.IncludeDeleted),cancellationToken);
            
            if(existingRoles.Count == 0)
                return EitherHelper<BaseSearchCommandResult<RoleGetAllCommandResult>>.EntityNotFound(typeof(Role));


            var totalRoles = await this._repository.Roles.CountAsync(new DefaultSearchSpecification<Role>(request.Filters.ToList(), new List<Sorting>(), request.Skip, request.Take, request.IncludeDeleted),cancellationToken);
            var roleResult = existingRoles.Select(x => new RoleGetAllCommandResult
            {
                RoleId = x.RoleId,
                Name = x.Name,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                DeletedAt = x.DeletedAt,
            }).ToList();
            
            
            
            var result = new BaseSearchCommandResult<RoleGetAllCommandResult>
            {
                Items = roleResult,
                Total =  totalRoles, 
            };

            return new Either<BaseSearchCommandResult<RoleGetAllCommandResult>>(result);
        }
    }
}