namespace Spoon.NuGet.SecureRemotePassword.Application.User.UserForgotPasswordRecoverByEmailSet;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;
using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
[PermissionPipelineBehaviourExclude("No claim required, using EmailProof")]
public sealed class UserForgotPasswordRecoverByEmailSetCommand : MediatorBaseCommand, IHandleableRequest<UserForgotPasswordRecoverByEmailSetCommand,
    UserForgotPasswordRecoverByEmailSetCommandHandler, Either<UserForgotPasswordRecoverByEmailSetCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserForgotPasswordRecoverByEmailSetCommand" /> class.
    /// </summary>
    public UserForgotPasswordRecoverByEmailSetCommand()
        : base(typeof(UserForgotPasswordRecoverByEmailSetCommand))
    {
    }

    /// <inheritdoc cref="UserForgotPasswordRecoverByEmailSetCommand" />
    public required string  Email { get; init; }

    /// <inheritdoc cref="UserForgotPasswordRecoverByEmailSetCommand" />
    public required string  Proof { get; init; }
    
    
}