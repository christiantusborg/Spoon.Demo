namespace Spoon.NuGet.SecureRemotePassword.Application.Roles.DeletePermanent;

using EitherCore;
using Mediator;
using Mediator.Interfaces;

/// <summary>
///     Represents a command to permanently delete a role.
/// </summary>
public sealed class RoleDeletePermanentCommand : MediatorBaseCommand, IHandleableRequest<RoleDeletePermanentCommand, RoleDeletePermanentCommandHandler, Either<RoleDeletePermanentCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="RoleDeletePermanentCommand" /> class.
    /// </summary>
    public RoleDeletePermanentCommand()
        : base(typeof(RoleDeletePermanentCommand))
    {
    }

    /// <summary>
    ///     Gets or sets the ID of the role to delete.
    /// </summary>
    /// <value>The ID of the role to delete.</value>
    public required Guid RoleId { get; init; }
}