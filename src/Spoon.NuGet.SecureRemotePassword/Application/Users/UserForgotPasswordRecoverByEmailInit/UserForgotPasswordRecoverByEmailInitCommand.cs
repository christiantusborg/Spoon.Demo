namespace Spoon.NuGet.SecureRemotePassword.Application.Users.UserForgotPasswordRecoverByEmailInit;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;
using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
[PermissionPipelineBehaviourExclude("No claim required, we send a email with a EmailProof")]
public sealed class UserForgotPasswordRecoverByEmailInitCommand : MediatorBaseCommand, IHandleableRequest<UserForgotPasswordRecoverByEmailInitCommand,
    UserForgotPasswordRecoverByEmailInitCommandHandler, Either<UserForgotPasswordRecoverByEmailInitCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserForgotPasswordRecoverByEmailInitCommand" /> class.
    /// </summary>
    public UserForgotPasswordRecoverByEmailInitCommand()
        : base(typeof(UserForgotPasswordRecoverByEmailInitCommand))
    {
    }

    /// <inheritdoc cref="UserForgotPasswordRecoverByEmailInitCommand" />
    public required string  Email { get; init; }
}