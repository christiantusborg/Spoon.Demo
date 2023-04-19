namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.UserRole.AddBulk;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class UserRoleAddBulkCommand : MediatorBaseCommand, IHandleableRequest<UserRoleAddBulkCommand,
    UserRoleAddBulkCommandHandler, Either<UserRoleAddBulkCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserRoleAddBulkCommand" /> class.
    /// </summary>
    public UserRoleAddBulkCommand()
        : base(typeof(UserRoleAddBulkCommand))
    {
    }

    /// <inheritdoc cref="UserRoleAddBulkCommand" />
    public Guid UserId { get; init; }

    /// <inheritdoc cref="UserRoleAddBulkCommand" />
    public List<Guid> Roles { get; set; } = new ();
}