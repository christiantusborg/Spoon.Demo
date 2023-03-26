
namespace Spoon.NuGet.SecureRemotePassword.Application.UserRole.AddBulk;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
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
    public List<Guid> Claims { get; set; }
}