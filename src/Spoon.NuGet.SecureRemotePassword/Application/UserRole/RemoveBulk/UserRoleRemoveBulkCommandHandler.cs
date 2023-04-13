namespace Spoon.NuGet.SecureRemotePassword.Application.UserRole.RemoveBulk;

using Core.Domain;
using Domain.Entities;
using Domain.Repositories;
using EitherCore;
using EitherCore.Helpers;
using MediatR;
using SharedSpecification;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class UserRoleRemoveBulkCommandHandler : IRequestHandler<UserRoleRemoveBulkCommand, Either<UserRoleRemoveBulkCommandResult>>
{
    private readonly ISecureRemotePasswordRepository _repository;

    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    public UserRoleRemoveBulkCommandHandler(ISecureRemotePasswordRepository repository)
    {
        this._repository = repository;
    }


    /// <summary>
    ///   Handles the specified request.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Either<UserRoleRemoveBulkCommandResult>> Handle(
        UserRoleRemoveBulkCommand request,
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
            return EitherHelper<UserRoleRemoveBulkCommandResult>.EntityNotFound(typeof(User));


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

        // ReSharper disable once RedundantSuppressNullableWarningExpression
        var newRoles = existingRoles.Intersect(existingUser.Roles!).ToList();


        foreach (var role in newRoles)
        {
            // ReSharper disable once RedundantSuppressNullableWarningExpression
            existingUser.Roles!.Remove(role);
        }

        await this._repository.SaveChangesAsync(cancellationToken);

        return new Either<UserRoleRemoveBulkCommandResult>(new UserRoleRemoveBulkCommandResult());
    }
}