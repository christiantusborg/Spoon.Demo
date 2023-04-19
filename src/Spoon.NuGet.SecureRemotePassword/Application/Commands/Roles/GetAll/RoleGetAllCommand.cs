namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Roles.GetAll;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommandSearch" />.
/// </summary>
/// <seealso cref="MediatorBaseCommandSearch" />
public sealed class RoleGetAllCommand : MediatorBaseCommandSearch, IHandleableRequest<RoleGetAllCommand,
    RoleGetAllCommandHandler, Either<BaseSearchCommandResult<RoleGetAllCommandResult>>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="RoleGetAllCommand" /> class.
    /// </summary>
    public RoleGetAllCommand()
        : base(typeof(RoleGetAllCommand))
    {
    }
}