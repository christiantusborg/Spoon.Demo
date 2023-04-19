namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Administration.SetUserPassword;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
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