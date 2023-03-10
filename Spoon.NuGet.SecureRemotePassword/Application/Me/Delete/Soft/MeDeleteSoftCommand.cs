namespace Spoon.NuGet.SecureRemotePassword.Application.Me.Delete.Soft;

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
public sealed class MeDeleteSoftCommand : MediatorBaseCommand, IHandleableRequest<MeDeleteSoftCommand,
    MeDeleteSoftCommandHandler, Either<MeDeleteSoftCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MeDeleteSoftCommand" /> class.
    /// </summary>
    public MeDeleteSoftCommand()
        : base(typeof(MeDeleteSoftCommand))
    {
    }

    /// <inheritdoc cref="MeDeleteSoftCommand" />
    public 
        Guid UserId { get; init; }

    public Guid EmailId { get; set; }
}