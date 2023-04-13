// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global

namespace Spoon.NuGet.SecureRemotePassword.Application.RolesClaims.AddBulk;

using EitherCore;
using Mediator;
using Mediator.Interfaces;

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
    public Guid RoleId { get; set; }

    /// <inheritdoc cref="RoleClaimAddBulkCommand" />
    public List<Guid> Claims { get; set; } = new ();
}