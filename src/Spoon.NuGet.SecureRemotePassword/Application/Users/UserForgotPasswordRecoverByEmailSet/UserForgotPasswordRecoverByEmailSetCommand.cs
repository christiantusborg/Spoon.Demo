// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Spoon.NuGet.SecureRemotePassword.Application.Users.UserForgotPasswordRecoverByEmailSet;

using EitherCore;
using Mediator;
using Mediator.Interfaces;
using Mediator.PipelineBehaviors.Permission;

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
    public required string RecoveryString { get; init; }

    /// <inheritdoc cref="UserForgotPasswordRecoverByEmailSetCommand" />
    public Guid UserId { get; init; }

    /// <inheritdoc cref="UserForgotPasswordRecoverByEmailSetCommand" />
    public required string Verifier { get; init; }

    /// <inheritdoc cref="UserForgotPasswordRecoverByEmailSetCommand" />
    public required string Salt { get; init; }
}