namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.DeleteUserPermanent;

using EitherCore;
using Mediator;
using Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
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