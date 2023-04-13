// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Spoon.NuGet.SecureRemotePassword.Application.Me.UserGenerateRecoveryCode;

using EitherCore;
using Mediator;
using Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
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