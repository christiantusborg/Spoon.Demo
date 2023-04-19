namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Users.UserForgotPasswordRecoverByRecoveryCodeSet;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
[PermissionPipelineBehaviourExclude("No claim required, using recovery code is proof")]
public sealed class UserForgotPasswordRecoverByRecoveryCodeSetCommand : MediatorBaseCommand, IHandleableRequest<UserForgotPasswordRecoverByRecoveryCodeSetCommand,
    UserForgotPasswordRecoverByRecoveryCodeSetCommandHandler, Either<UserForgotPasswordRecoverByRecoverySetChallengeGetCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserForgotPasswordRecoverByRecoveryCodeSetCommand" /> class.
    /// </summary>
    public UserForgotPasswordRecoverByRecoveryCodeSetCommand()
        : base(typeof(UserForgotPasswordRecoverByRecoveryCodeSetCommand))
    {
    }

    /// <inheritdoc cref="UserForgotPasswordRecoverByRecoveryCodeSetCommand" />
    public required string UsernameHashed { get; init; }

    /// <inheritdoc cref="UserForgotPasswordRecoverByRecoveryCodeSetCommand" />
    public required string Verifier { get; init; }

    /// <inheritdoc cref="UserForgotPasswordRecoverByRecoveryCodeSetCommand" />
    public required string Salt { get; init; }
}