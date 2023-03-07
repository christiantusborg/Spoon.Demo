namespace Spoon.NuGet.SecureRemotePassword.Application.User.UserForgotPasswordRecoverByRecoveryCodeInit;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;
using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
[PermissionPipelineBehaviourExclude("No claim required, using recovery code is proof")]
public sealed class UserForgotPasswordRecoverByRecoveryCodeCommand : MediatorBaseCommand, IHandleableRequest<UserForgotPasswordRecoverByRecoveryCodeCommand,
    UserForgotPasswordRecoverByRecoveryCodeCommandHandler, Either<UserForgotPasswordRecoverByRecoveryCodeCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserForgotPasswordRecoverByRecoveryCodeCommand" /> class.
    /// </summary>
    public UserForgotPasswordRecoverByRecoveryCodeCommand()
        : base(typeof(UserForgotPasswordRecoverByRecoveryCodeCommand))
    {
    }

    /// <inheritdoc cref="UserForgotPasswordRecoverByRecoveryCodeCommand" />
    public required string  Email { get; init; }

    /// <inheritdoc cref="UserForgotPasswordRecoverByRecoveryCodeCommand" />
    public required string  RecoveryCode { get; init; }
    
    /// <inheritdoc cref="UserForgotPasswordRecoverByRecoveryCodeCommand" />
    public required string Verifier { get; init; }

    /// <inheritdoc cref="UserForgotPasswordRecoverByRecoveryCodeCommand" />
    public required string Salt { get; init; }
    
    
}