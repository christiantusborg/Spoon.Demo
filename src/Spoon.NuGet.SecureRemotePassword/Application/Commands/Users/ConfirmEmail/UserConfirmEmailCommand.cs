namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Users.ConfirmEmail;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
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
    public Guid EmailId { get; init; }

    /// <inheritdoc cref="UserConfirmEmailCommand" />
    public string? ConfirmCode { get; init; }
}