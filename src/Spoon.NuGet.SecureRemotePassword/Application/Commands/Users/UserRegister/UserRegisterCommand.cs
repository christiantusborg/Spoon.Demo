// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Users.UserRegister;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class UserRegisterCommand : MediatorBaseCommand, IHandleableRequest<UserRegisterCommand,
    UserRegisterCommandHandler, Either<UserRegisterCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserRegisterCommand" /> class.
    /// </summary>
    public UserRegisterCommand()
        : base(typeof(UserRegisterCommand))
    {
    }

    /// <inheritdoc cref="UserRegisterCommand" />
    public Guid UserId { get; set; }

    /// <inheritdoc cref="UserRegisterCommand" />
    public required string UsernameHash { get; init; }

    /// <inheritdoc cref="UserRegisterCommand" />
    public required string Email { get; init; }

    /// <inheritdoc cref="UserRegisterCommand" />
    public required string Verifier { get; init; }

    /// <inheritdoc cref="UserRegisterCommand" />
    public required string Salt { get; init; }
}