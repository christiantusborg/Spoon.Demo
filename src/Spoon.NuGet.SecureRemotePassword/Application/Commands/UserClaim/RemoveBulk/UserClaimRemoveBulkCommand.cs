// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.UserClaim.RemoveBulk;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
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