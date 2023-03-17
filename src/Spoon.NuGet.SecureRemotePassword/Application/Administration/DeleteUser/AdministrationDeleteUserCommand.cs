namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.DeleteUser;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
public sealed class AdministrationDeleteUserCommand : MediatorBaseCommand, IHandleableRequest<AdministrationDeleteUserCommand,
    AdministrationDeleteUserCommandHandler, Either<AdministrationDeleteUserCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AdministrationDeleteUserCommand" /> class.
    /// </summary>
    public AdministrationDeleteUserCommand()
        : base(typeof(AdministrationDeleteUserCommand))
    {
    }

    /// <inheritdoc cref="AdministrationDeleteUserCommand" />
    public 
        Guid UserId { get; init; }


}