namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.SetUserAllowedLogin;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
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