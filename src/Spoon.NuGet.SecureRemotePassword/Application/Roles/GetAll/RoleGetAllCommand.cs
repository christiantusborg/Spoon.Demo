
namespace Spoon.NuGet.SecureRemotePassword.Application.Roles.GetAll;

using Core.Application;
using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
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