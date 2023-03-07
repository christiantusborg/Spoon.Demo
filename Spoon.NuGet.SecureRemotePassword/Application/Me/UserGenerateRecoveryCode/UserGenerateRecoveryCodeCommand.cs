namespace Spoon.NuGet.SecureRemotePassword.Application.Me.UserGenerateRecoveryCode;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;

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
}