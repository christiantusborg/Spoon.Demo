namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.UserClaim.AddBulk;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class UserClaimAddBulkCommand : MediatorBaseCommand, IHandleableRequest<UserClaimAddBulkCommand,
    UserClaimAddBulkCommandHandler, Either<UserClaimAddBulkCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserClaimAddBulkCommand" /> class.
    /// </summary>
    public UserClaimAddBulkCommand()
        : base(typeof(UserClaimAddBulkCommand))
    {
    }

    /// <inheritdoc cref="UserClaimAddBulkCommand" />
    public Guid UserId { get; init; }

    /// <inheritdoc cref="UserClaimAddBulkCommand" />
    public List<Guid> Claims { get; init; } = new ();
}