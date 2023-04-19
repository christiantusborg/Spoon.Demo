// ReSharper disable PropertyCanBeMadeInitOnly.Global

namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Users.UserLogoutAll;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class UserLogoutAllCommand : MediatorBaseCommand, IHandleableRequest<UserLogoutAllCommand,
    UserLogoutAllCommandHandler, Either<UserLogoutAllCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserLogoutAllCommand" /> class.
    /// </summary>
    public UserLogoutAllCommand()
        : base(typeof(UserLogoutAllCommand))
    {
    }

    /// <inheritdoc cref="UserLogoutAllCommand" />
    public required Guid UserId { get; set; }
}