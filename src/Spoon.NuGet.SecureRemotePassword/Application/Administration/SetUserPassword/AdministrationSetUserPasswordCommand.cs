
namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.SetUserPassword;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
public sealed class AdministrationSetUserPasswordCommand : MediatorBaseCommand, IHandleableRequest<AdministrationSetUserPasswordCommand,
    AdministrationSetUserPasswordCommandHandler, Either<AdministrationSetUserPasswordCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AdministrationSetUserPasswordCommand" /> class.
    /// </summary>
    public AdministrationSetUserPasswordCommand()
        : base(typeof(AdministrationSetUserPasswordCommand))
    {
    }

    /// <inheritdoc cref="AdministrationSetUserPasswordCommand" />
    public Guid UserId { get; init; }
    /// <inheritdoc cref="AdministrationSetUserPasswordCommand" />
    public required string Verifier { get; init; }
    /// <inheritdoc cref="AdministrationSetUserPasswordCommand" />
    public required string Salt { get; init; }

 


}