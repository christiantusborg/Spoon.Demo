namespace Spoon.NuGet.SecureRemotePassword.Application.Roles.Get;

using System.Diagnostics.CodeAnalysis;
using Core.Application;
using Domain.Entities;
using Domain.Repositories;
using EitherCore;
using EitherCore.Helpers;
using MediatR;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
public sealed class RoleGetCommandHandler : IRequestHandler<RoleGetCommand, Either<RoleGetCommandResult>>
{
    private readonly ISecureRemotePasswordRepository _repository;

    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    public RoleGetCommandHandler(ISecureRemotePasswordRepository repository)
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
    public async Task<Either<RoleGetCommandResult>> Handle(
        RoleGetCommand request,
        CancellationToken cancellationToken)
    {
        var existingRole = await this._repository.Roles.GetAsync(new DefaultGetSpecification<Role>(request.RoleId), cancellationToken);

        if (existingRole == null)
            return EitherHelper<RoleGetCommandResult>.EntityNotFound(typeof(User));


        var result = new RoleGetCommandResult
        {
            RoleId = existingRole.RoleId,
            Name = existingRole.Name,
            CreatedAt = existingRole.CreatedAt,
            UpdatedAt = existingRole.UpdatedAt,
            DeletedAt = existingRole.DeletedAt,
        };

        return new Either<RoleGetCommandResult>(result);
    }
}