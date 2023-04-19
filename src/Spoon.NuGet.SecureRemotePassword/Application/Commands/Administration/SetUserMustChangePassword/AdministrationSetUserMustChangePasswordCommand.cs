namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Administration.SetUserMustChangePassword;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class AdministrationSetUserMustChangePasswordCommand : MediatorBaseCommand, IHandleableRequest<AdministrationSetUserMustChangePasswordCommand,
    AdministrationSetUserMustChangePasswordCommandHandler, Either<AdministrationSetUserMustChangePasswordCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AdministrationSetUserMustChangePasswordCommand" /> class.
    /// </summary>
    public AdministrationSetUserMustChangePasswordCommand()
        : base(typeof(AdministrationSetUserMustChangePasswordCommand))
    {
    }

    /// <inheritdoc cref="AdministrationSetUserMustChangePasswordCommand" />
    public Guid UserId { get; init; }

    /// <inheritdoc cref="AdministrationSetUserMustChangePasswordCommand" />
    public bool Value { get; init; }
}