namespace Spoon.NuGet.SecureRemotePassword.Application.Me.Email.SetAsPrimaryEmail;

using EitherCore;
using Mediator;
using Mediator.Interfaces;
using Mediator.PipelineBehaviors.Permission;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
[PermissionPipelineBehaviourExclude("No claim required using Secure Remote Password ClientSessionProof")]
public sealed class MeEmailSetAsPrimaryCommand : MediatorBaseCommand, IHandleableRequest<MeEmailSetAsPrimaryCommand,
    MeEmailSetAsPrimaryCommandHandler, Either<MeEmailSetAsPrimaryCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MeEmailSetAsPrimaryCommand" /> class.
    /// </summary>
    public MeEmailSetAsPrimaryCommand()
        : base(typeof(MeEmailSetAsPrimaryCommand))
    {
    }

    /// <inheritdoc cref="MeEmailSetAsPrimaryCommand" />
    public Guid UserId { internal get; set; }
    /// <inheritdoc cref="MeEmailSetAsPrimaryCommand" />
    public required Guid EmailId { get; init; }
}