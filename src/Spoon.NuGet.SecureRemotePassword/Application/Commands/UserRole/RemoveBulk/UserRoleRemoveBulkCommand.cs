namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.UserRole.RemoveBulk;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class UserRoleRemoveBulkCommand : MediatorBaseCommand, IHandleableRequest<UserRoleRemoveBulkCommand,
    UserRoleRemoveBulkCommandHandler, Either<UserRoleRemoveBulkCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserRoleRemoveBulkCommand" /> class.
    /// </summary>
    public UserRoleRemoveBulkCommand()
        : base(typeof(UserRoleRemoveBulkCommand))
    {
    }

    /// <inheritdoc cref="UserRoleRemoveBulkCommand" />
    public required Guid UserId { get; init; }

    /// <inheritdoc cref="UserRoleRemoveBulkCommand" />
    public List<Guid> Roles { get; set; } = new ();
}