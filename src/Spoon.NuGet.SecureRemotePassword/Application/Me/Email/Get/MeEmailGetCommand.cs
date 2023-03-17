namespace Spoon.NuGet.SecureRemotePassword.Application.Me.Email.Get;

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
public sealed class MeEmailGetCommand : MediatorBaseCommand, IHandleableRequest<MeEmailGetCommand,
    MeEmailGetCommandHandler, Either<MeEmailGetCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MeEmailGetCommand" /> class.
    /// </summary>
    public MeEmailGetCommand()
        : base(typeof(MeEmailGetCommand))
    {
    }

    /// <inheritdoc cref="MeEmailGetCommand" />
    public 
        Guid EmailId { get; init; }

    /// <inheritdoc cref="MeEmailGetCommand" />
    public Guid UserId { get; set; }
}