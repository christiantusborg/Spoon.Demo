// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Me.UserGenerateRecoveryCode;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class UserGenerateRecoveryCodeCommand : MediatorBaseCommand, IHandleableRequest<UserGenerateRecoveryCodeCommand,
    UserGenerateRecoveryCodeCommandHandler, Either<UserGenerateRecoveryCodeCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserGenerateRecoveryCodeCommand" /> class.
    /// </summary>
    public UserGenerateRecoveryCodeCommand()
        : base(typeof(UserGenerateRecoveryCodeCommand))
    {
    }

    /// <inheritdoc cref="UserGenerateRecoveryCodeCommand" />
    public Guid UserId { get; init; }
}