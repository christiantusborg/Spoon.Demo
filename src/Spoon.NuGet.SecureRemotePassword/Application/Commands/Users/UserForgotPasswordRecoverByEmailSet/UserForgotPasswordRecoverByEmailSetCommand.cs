// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Users.UserForgotPasswordRecoverByEmailSet;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
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