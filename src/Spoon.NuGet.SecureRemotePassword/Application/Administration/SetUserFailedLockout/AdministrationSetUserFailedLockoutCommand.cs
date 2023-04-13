// ReSharper disable PropertyCanBeMadeInitOnly.Global
namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.SetUserFailedLockout;

using EitherCore;
using Mediator;
using Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
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