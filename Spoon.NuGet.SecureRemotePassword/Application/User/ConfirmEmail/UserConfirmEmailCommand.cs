namespace Spoon.NuGet.SecureRemotePassword.Application.User.ConfirmEmail;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;
using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
[PermissionPipelineBehaviourExclude("No claim required need to be able confirm email with login.")]
public sealed class UserConfirmEmailCommand : MediatorBaseCommand, IHandleableRequest<UserConfirmEmailCommand,
    UserConfirmEmailCommandHandler, Either<UserConfirmEmailCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserConfirmEmailCommand" /> class.
    /// </summary>
    public UserConfirmEmailCommand()
        : base(typeof(UserConfirmEmailCommand))
    {
    }

    /// <inheritdoc cref="UserConfirmEmailCommand" />
    public string? ConfirmCode { get; init; }
}