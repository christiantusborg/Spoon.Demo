namespace Spoon.NuGet.SecureRemotePassword.Application.Users.UserForgotPasswordRecoverByRecoveryCodeChallengeGet;

using EitherCore;
using Mediator;
using Mediator.Interfaces;
using Mediator.PipelineBehaviors.Permission;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
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
    public required string UsernameHashed { get; init; }
}