namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Administration.DeleteUserPermanent;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class AdministrationDeleteUserPermanentCommand : MediatorBaseCommand, IHandleableRequest<AdministrationDeleteUserPermanentCommand,
    AdministrationDeleteUserPermanentCommandHandler, Either<AdministrationDeleteUserPermanentCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AdministrationDeleteUserPermanentCommand" /> class.
    /// </summary>
    public AdministrationDeleteUserPermanentCommand()
        : base(typeof(AdministrationDeleteUserPermanentCommand))
    {
    }

    /// <inheritdoc cref="AdministrationDeleteUserPermanentCommand" />
    public Guid UserId { get; init; }

    /// <inheritdoc cref="AdministrationDeleteUserPermanentCommand" />
    public Guid CurrentUserId { get; set; }
}