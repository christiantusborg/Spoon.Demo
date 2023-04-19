namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Roles.Update;

using Core;
using Core.Application;
using Domain.Entities;
using Domain.Repositories;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class RoleUpdateCommandHandler : IRequestHandler<RoleUpdateCommand, Either<RoleUpdateCommandResult>>
{
    private readonly ISecureRemotePasswordRepository _repository;
    private readonly IMockbleDateTime _mockbleDateTime;

    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="mockbleDateTime"></param>
    public RoleUpdateCommandHandler(ISecureRemotePasswordRepository repository, IMockbleDateTime mockbleDateTime)
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
        existingRole.UpdatedAt = this._mockbleDateTime.UtcNow;

        // Save changes to the repository.
        await this._repository.SaveChangesAsync(cancellationToken);

        // Return an Either instance with the RoleCreateCommandResult.
        return new Either<RoleUpdateCommandResult>(new RoleUpdateCommandResult());
    }
}