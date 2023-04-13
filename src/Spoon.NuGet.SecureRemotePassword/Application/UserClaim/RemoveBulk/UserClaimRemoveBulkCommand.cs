
// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Spoon.NuGet.SecureRemotePassword.Application.UserClaim.RemoveBulk;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
public sealed class UserClaimRemoveBulkCommand : MediatorBaseCommand, IHandleableRequest<UserClaimRemoveBulkCommand,
    UserClaimRemoveBulkCommandHandler, Either<UserClaimRemoveBulkCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserClaimRemoveBulkCommand" /> class.
    /// </summary>
    public UserClaimRemoveBulkCommand()
        : base(typeof(UserClaimRemoveBulkCommand))
    {
    }

    /// <inheritdoc cref="UserClaimRemoveBulkCommand" />
    public Guid UserId { get; init; }
    /// <inheritdoc cref="UserClaimRemoveBulkCommand" />
    public List<Guid> Claims { get; init; } = new ();
}