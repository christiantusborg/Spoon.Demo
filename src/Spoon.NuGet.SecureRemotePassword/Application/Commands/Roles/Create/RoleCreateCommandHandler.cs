namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Roles.Create;

using System.Diagnostics.CodeAnalysis;
using Core;
using Domain.Entities;
using Domain.Repositories;

/// <summary>
///     Command handler for creating a new role in the system.
/// </summary>
[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
public sealed class RoleCreateCommandHandler : IRequestHandler<RoleCreateCommand, Either<RoleCreateCommandResult>>
{
    private readonly IMockbleGuidGenerator _mockbleGuidGenerator;
    private readonly IMockbleDateTime _mockbleDateTime;
    private readonly ISecureRemotePasswordRepository _repository;

    /// <summary>
    ///     Initializes a new instance of the <see cref="RoleCreateCommandHandler" /> class.
    /// </summary>
    /// <param name="mockbleGuidGenerator">A mockable GUID generator.</param>
    /// <param name="mockbleDateTime">A mockable date and time service.</param>
    /// <param name="repository">The repository for roles.</param>
    public RoleCreateCommandHandler(IMockbleGuidGenerator mockbleGuidGenerator, IMockbleDateTime mockbleDateTime, ISecureRemotePasswordRepository repository)
    {
        this._mockbleGuidGenerator = mockbleGuidGenerator;
        this._mockbleDateTime = mockbleDateTime;
        this._repository = repository;
    }

    /// <inheritdoc />
    public async Task<Either<RoleCreateCommandResult>> Handle(
        RoleCreateCommand request,
        CancellationToken cancellationToken)
    {
        // Check if a role with the specified name already exists in the repository.
        var existingRole = await this._repository.Roles.GetAsync(new RoleCreateCommandSpecification(request.Name), cancellationToken);

        // If a role with the specified name already exists, return an error message.
        if (existingRole != null)
            return EitherHelper<RoleCreateCommandResult>.EntityAlreadyExists(typeof(Role));

        // Generate a new GUID for the role.
        var roleId = this._mockbleGuidGenerator.NewGuid();

        // Create a new Role object with the specified name, generated GUID, and current date and time for the CreatedAt and UpdatedAt properties.
        var role = new Role
        {
            RoleId = roleId,
            Name = request.Name,
            CreatedAt = this._mockbleDateTime.UtcNow,
            UpdatedAt = this._mockbleDateTime.UtcNow,
        };

        // Add the new role to the repository.
        this._repository.Roles.Add(role);

        // Save changes to the repository.
        await this._repository.SaveChangesAsync(cancellationToken);

        // Create a new RoleCreateCommandResult object with the GUID of the newly created role.
        var result = new RoleCreateCommandResult
        {
            RoleId = roleId,
        };

        // Return an Either instance with the RoleCreateCommandResult.
        return new Either<RoleCreateCommandResult>(result);
    }
}