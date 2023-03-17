namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.GetAllUser;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
public sealed class AdministrationGetAllUserCommand : MediatorBaseCommand, IHandleableRequest<AdministrationGetAllUserCommand,
    AdministrationGetAllUserCommandHandler, Either<AdministrationGetAllUserCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AdministrationGetAllUserCommand" /> class.
    /// </summary>
    public AdministrationGetAllUserCommand()
        : base(typeof(AdministrationGetAllUserCommand))
    {
    }
}