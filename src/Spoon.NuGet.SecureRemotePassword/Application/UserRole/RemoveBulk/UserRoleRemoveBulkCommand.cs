
namespace Spoon.NuGet.SecureRemotePassword.Application.UserRole.RemoveBulk;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
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
    public List<Guid> Roles { get; set; } = new List<Guid>();
}