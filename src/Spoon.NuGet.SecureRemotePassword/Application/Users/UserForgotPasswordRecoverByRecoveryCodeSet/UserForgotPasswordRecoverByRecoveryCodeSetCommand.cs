namespace Spoon.NuGet.SecureRemotePassword.Application.Users.UserForgotPasswordRecoverByRecoveryCodeSet;

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
    public required Guid UserId { get; init; }

    /// <inheritdoc cref="UserForgotPasswordRecoverByRecoveryCodeSetCommand" />
    public required string Verifier { get; init; }

    /// <inheritdoc cref="UserForgotPasswordRecoverByRecoveryCodeSetCommand" />
    public required string Salt { get; init; }
}