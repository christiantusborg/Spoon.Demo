namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.GetAllUser;

using Core.Application;
using EitherCore;
using Mediator.Interfaces;

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