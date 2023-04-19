// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Users.UserLogout;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class UserLogoutCommand : MediatorBaseCommand, IHandleableRequest<UserLogoutCommand,
    UserLogoutCommandHandler, Either<UserLogoutCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserLogoutCommand" /> class.
    /// </summary>
    public UserLogoutCommand()
        : base(typeof(UserLogoutCommand))
    {
    }

    /// <inheritdoc cref="UserLogoutCommand" />
    public required Guid UserId { get; set; }

    /// <inheritdoc cref="UserLogoutCommand" />
    public required Guid SessionId { get; set; }
}