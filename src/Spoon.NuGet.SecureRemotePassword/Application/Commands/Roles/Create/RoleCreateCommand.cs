namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Roles.Create;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Represents a request to create a new role, which is handled by a <see cref="RoleCreateCommandHandler" /> using the
///     MediatR framework.
/// </summary>
public sealed class RoleCreateCommand : MediatorBaseCommand, IHandleableRequest<RoleCreateCommand,
    RoleCreateCommandHandler, Either<RoleCreateCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="RoleCreateCommand" /> class.
    /// </summary>
    public RoleCreateCommand()
        : base(typeof(RoleCreateCommand))
    {
    }

    /// <summary>
    ///     Gets or sets the name of the new role.
    /// </summary>
    public required string Name { get; init; }
}