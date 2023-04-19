// ReSharper disable PropertyCanBeMadeInitOnly.Global

namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Administration.SetUserFailedLockout;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class AdministrationSetUserFailedLockoutCommand : MediatorBaseCommand, IHandleableRequest<AdministrationSetUserFailedLockoutCommand,
    AdministrationSetUserFailedLockoutCommandHandler, Either<AdministrationSetUserFailedLockoutCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AdministrationSetUserFailedLockoutCommand" /> class.
    /// </summary>
    public AdministrationSetUserFailedLockoutCommand()
        : base(typeof(AdministrationSetUserFailedLockoutCommand))
    {
    }

    /// <inheritdoc cref="AdministrationSetUserFailedLockoutCommand" />
    public Guid UserId { get; init; }

    /// <inheritdoc cref="AdministrationSetUserFailedLockoutCommand" />
    public bool Value { get; set; }
}