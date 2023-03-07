namespace Spoon.NuGet.SecureRemotePassword.Application.Me.Delete.Permanent;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;
using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
[PermissionPipelineBehaviourExclude("No claim required using Secure Remote Password ClientSessionProof")]
public sealed class MeDeletePermanentCommand : MediatorBaseCommand, IHandleableRequest<MeDeletePermanentCommand,
    MeDeletePermanentCommandHandler, Either<MeDeletePermanentCommandCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserDeleteSoftCommand" /> class.
    /// </summary>
    public MeDeletePermanentCommand()
        : base(typeof(MeDeletePermanentCommand))
    {
    }

    /// <inheritdoc cref="UserDeleteSoftCommand" />
    public Guid UserId { get; init; }
    /// <inheritdoc cref="UserDeleteSoftCommand" />
    public Guid EmailId { get; init; }
}