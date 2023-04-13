// ReSharper disable ClassNeverInstantiated.Global
namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.GetAllUser;

using Core.Application;
using Core.Domain;
using Domain.Entities;
using Domain.Repositories;
using EitherCore;
using MediatR;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class AdministrationGetAllUserCommandHandler : IRequestHandler<AdministrationGetAllUserCommand, Either<BaseSearchCommandResult<AdministrationGetAllUserCommandResult>>>
{
    private readonly ISecureRemotePasswordRepository _repository;

    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    public AdministrationGetAllUserCommandHandler(ISecureRemotePasswordRepository repository)
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
    public async Task<Either<BaseSearchCommandResult<AdministrationGetAllUserCommandResult>>> Handle(
        AdministrationGetAllUserCommand request,
        CancellationToken cancellationToken)
    {
        var existingUser = await this._repository.Users.SearchAsync(new DefaultSearchSpecification<User>(request.Filters, request.SortField, request.Skip, request.Take, request.IncludeDeleted),
            cancellationToken);

        if (existingUser.Count == 0)
            return new Either<BaseSearchCommandResult<AdministrationGetAllUserCommandResult>>(new BaseSearchCommandResult<AdministrationGetAllUserCommandResult>());


        var total = await this._repository.Users.CountAsync(new DefaultSearchSpecification<User>(request.Filters.ToList(), new List<Sorting>(), request.Skip, request.Take, request.IncludeDeleted),
            cancellationToken);


        var result = new BaseSearchCommandResult<AdministrationGetAllUserCommandResult>
        {
            Items = existingUser.Select(x => new AdministrationGetAllUserCommandResult
            {
                UserId = x.UserId,
                MustChangePassword = x.MustChangePassword,
                CreatedAt = x.CreatedAt,
                DeletedAt = x.DeletedAt,
                DisabledAt = x.DisabledAt,
                LastLogin = x.LastLogin,
                LockoutCount = x.LockoutCount,
                LockoutEnd = x.LockoutEnd,
                UpdatedAt = x.UpdatedAt,
            }).ToList(),
            Total = total,
        };

        return new Either<BaseSearchCommandResult<AdministrationGetAllUserCommandResult>>(result);
    }
}