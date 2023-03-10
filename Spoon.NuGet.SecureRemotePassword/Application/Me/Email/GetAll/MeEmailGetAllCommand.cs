namespace Spoon.NuGet.SecureRemotePassword.Application.Me.Email.GetAll;

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
public sealed class MeEmailGetAllCommand : MediatorBaseCommand, IHandleableRequest<MeEmailGetAllCommand,
    MeEmailGetAllCommandHandler, Either<MeEmailGetAllCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MeEmailGetAllCommand" /> class.
    /// </summary>
    public MeEmailGetAllCommand()
        : base(typeof(MeEmailGetAllCommand))
    {
    }

    /// <inheritdoc cref="MeEmailGetAllCommand" />
    public 
        Guid UserId { get; init; }
}