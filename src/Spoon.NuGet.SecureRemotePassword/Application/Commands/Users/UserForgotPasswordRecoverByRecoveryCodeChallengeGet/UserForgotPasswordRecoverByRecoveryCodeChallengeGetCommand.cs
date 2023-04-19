namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Users.UserForgotPasswordRecoverByRecoveryCodeChallengeGet;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
[PermissionPipelineBehaviourExclude("No claim required, using recovery code is proof")]
public sealed class UserForgotPasswordRecoverByRecoveryCodeChallengeGetCommand : MediatorBaseCommand, IHandleableRequest<UserForgotPasswordRecoverByRecoveryCodeChallengeGetCommand,
    UserForgotPasswordRecoverByRecoveryCodeChallengeGetCommandHandler, Either<UserForgotPasswordRecoverByRecoveryCodeChallengeGetCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserForgotPasswordRecoverByRecoveryCodeChallengeGetCommand" /> class.
    /// </summary>
    public UserForgotPasswordRecoverByRecoveryCodeChallengeGetCommand()
        : base(typeof(UserForgotPasswordRecoverByRecoveryCodeChallengeGetCommand))
    {
    }

    /// <inheritdoc cref="UserForgotPasswordRecoverByRecoveryCodeChallengeGetCommand" />
    public string UsernameHashed { get; set; }
}