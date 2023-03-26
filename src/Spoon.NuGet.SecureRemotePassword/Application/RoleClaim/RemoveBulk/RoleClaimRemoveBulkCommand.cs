
namespace Spoon.NuGet.SecureRemotePassword.Application.RoleClaim.RemoveBulk;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
public sealed class RoleClaimRemoveBulkCommand : MediatorBaseCommand, IHandleableRequest<RoleClaimRemoveBulkCommand,
    RoleClaimRemoveBulkCommandHandler, Either<RoleClaimRemoveBulkCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="RoleClaimRemoveBulkCommand" /> class.
    /// </summary>
    public RoleClaimRemoveBulkCommand()
        : base(typeof(RoleClaimRemoveBulkCommand))
    {
    }

    /// <inheritdoc cref="RoleClaimRemoveBulkCommand" />
    public Guid UserId { get; init; }
    /// <inheritdoc cref="RoleClaimRemoveBulkCommand" />
    public List<Guid> Claims { get; set; } = new List<Guid>();



}