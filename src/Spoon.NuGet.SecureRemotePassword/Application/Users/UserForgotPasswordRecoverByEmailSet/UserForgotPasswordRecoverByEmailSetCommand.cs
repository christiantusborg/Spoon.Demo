namespace Spoon.NuGet.SecureRemotePassword.Application.Users.UserForgotPasswordRecoverByEmailSet;

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
public sealed class UserForgotPasswordRecoverByEmailSetCommand : MediatorBaseCommand, IHandleableRequest< UserForgotPasswordRecoverByEmailSetCommand,
    UserForgotPasswordRecoverByEmailSetCommandHandler, Either<UserForgotPasswordRecoverByEmailSetCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserForgotPasswordSetByEmailCommand" /> class.
    /// </summary>
    public UserForgotPasswordRecoverByEmailSetCommand()
        : base(typeof(UserForgotPasswordRecoverByEmailSetCommand))
    {
    }

    /// <inheritdoc cref="UserForgotPasswordSetByEmailCommand" />
    public required string  Email { get; init; }

    /// <inheritdoc cref="UserForgotPasswordSetByEmailCommand" />
    public required string  Proof { get; init; }
    
    /// <inheritdoc cref="UserForgotPasswordSetByEmailCommand" />
    public required string Verifier { get; init; }

    /// <inheritdoc cref="UserForgotPasswordSetByEmailCommand" />
    public required string Salt { get; init; }
    
    
}