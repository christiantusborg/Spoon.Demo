namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.SetUserMustChangePassword;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
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
    public bool Value { get; set; }

 


}