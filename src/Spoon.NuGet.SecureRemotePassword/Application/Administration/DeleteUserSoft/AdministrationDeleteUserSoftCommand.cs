namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.DeleteUserSoft;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
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

    public required Guid CurrentUserId { get; set; }
}