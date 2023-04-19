namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Administration.DeleteUserSoft;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class AdministrationDeleteUserSoftCommand : MediatorBaseCommand, IHandleableRequest<AdministrationDeleteUserSoftCommand,
    AdministrationDeleteUserSoftCommandHandler, Either<AdministrationDeleteUserSoftCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AdministrationDeleteUserSoftCommand" /> class.
    /// </summary>
    public AdministrationDeleteUserSoftCommand()
        : base(typeof(AdministrationDeleteUserSoftCommand))
    {
    }

    /// <inheritdoc cref="AdministrationDeleteUserSoftCommand" />
    public required Guid UserId { get; init; }

    /// <inheritdoc cref="AdministrationDeleteUserSoftCommand" />
    public required Guid CurrentUserId { get; set; }
}