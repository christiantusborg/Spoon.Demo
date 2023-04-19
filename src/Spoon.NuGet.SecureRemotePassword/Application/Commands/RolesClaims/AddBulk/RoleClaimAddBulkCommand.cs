// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PropertyCanBeMadeInitOnly.Global

namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.RolesClaims.AddBulk;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
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