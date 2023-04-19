namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Administration.GetAllUser;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
/// </summary>
public sealed class AdministrationGetAllUserCommand : MediatorBaseCommandSearch, IHandleableRequest<AdministrationGetAllUserCommand,
    AdministrationGetAllUserCommandHandler, Either<BaseSearchCommandResult<AdministrationGetAllUserCommandResult>>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="AdministrationGetAllUserCommand" /> class.
    /// </summary>
    public AdministrationGetAllUserCommand()
        : base(typeof(AdministrationGetAllUserCommand))
    {
    }
}