namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Administration.SetUserAllowedLogin;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class AdministrationSetUserAllowedLoginCommand : MediatorBaseCommand, IHandleableRequest<AdministrationSetUserAllowedLoginCommand,
    AdministrationSetUserAllowedLoginCommandHandler, Either<AdministrationSetUserAllowedLoginCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AdministrationSetUserAllowedLoginCommand" /> class.
    /// </summary>
    public AdministrationSetUserAllowedLoginCommand()
        : base(typeof(AdministrationSetUserAllowedLoginCommand))
    {
    }

    /// <inheritdoc cref="AdministrationSetUserAllowedLoginCommand" />
    public Guid UserId { get; init; }

    /// <inheritdoc cref="AdministrationSetUserAllowedLoginCommand" />
    public bool Value { get; set; }
}