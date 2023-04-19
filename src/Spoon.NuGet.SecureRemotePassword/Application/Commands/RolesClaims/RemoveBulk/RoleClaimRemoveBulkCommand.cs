namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.RolesClaims.RemoveBulk;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
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
    public Guid RoleId { get; init; }

    /// <inheritdoc cref="RoleClaimRemoveBulkCommand" />
    public List<Guid> Claims { get; set; } = new ();
}