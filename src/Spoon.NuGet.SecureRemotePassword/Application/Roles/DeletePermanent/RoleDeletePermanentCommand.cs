namespace Spoon.NuGet.SecureRemotePassword.Application.Roles.DeletePermanent;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;

public sealed class RoleDeletePermanentCommand : MediatorBaseCommand, IHandleableRequest<RoleDeletePermanentCommand,
    RoleDeletePermanentCommandHandler, Either<RoleDeletePermanentCommandResult>>
{
    public RoleDeletePermanentCommand()
        : base(typeof(RoleDeletePermanentCommand))
    {
    }

    public required Guid RoleId { get; init; }
}