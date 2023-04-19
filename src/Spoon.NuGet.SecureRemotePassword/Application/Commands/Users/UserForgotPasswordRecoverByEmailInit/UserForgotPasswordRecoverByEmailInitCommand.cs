namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Users.UserForgotPasswordRecoverByEmailInit;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
[PermissionPipelineBehaviourExclude("No claim required, we send a email with a link to recover password.")]
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
    public required string Email { get; init; }
}