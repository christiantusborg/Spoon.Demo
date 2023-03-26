
namespace Spoon.NuGet.SecureRemotePassword.Application.RoleClaim.AddBulk;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
public sealed class RoleClaimAddBulkCommand : MediatorBaseCommand, IHandleableRequest<RoleClaimAddBulkCommand,
    RoleClaimAddBulkCommandHandler, Either<RoleClaimAddBulkCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="RoleClaimAddBulkCommand" /> class.
    /// </summary>
    public RoleClaimAddBulkCommand()
        : base(typeof(RoleClaimAddBulkCommand))
    {
    }

    /// <inheritdoc cref="RoleClaimAddBulkCommand" />
    public Guid UserId { get; init; }
    /// <inheritdoc cref="RoleClaimAddBulkCommand" />
    public List<Guid> Claims { get; set; } = new List<Guid>();



}