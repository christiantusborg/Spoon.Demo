namespace Spoon.NuGet.SecureRemotePassword.Application.Me.Email.Create;

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
public sealed class MeEmailCreateEmailCommand : MediatorBaseCommand, IHandleableRequest<MeEmailCreateEmailCommand,
    MeEmailCreateCommandHandler, Either<MeEmailCreateCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MeEmailCreateEmailCommand" /> class.
    /// </summary>
    public MeEmailCreateEmailCommand()
        : base(typeof(MeEmailCreateEmailCommand))
    {
    }

    /// <inheritdoc cref="MeEmailCreateEmailCommand" />
    public 
        Guid UserId { get; init; }

    /// <inheritdoc cref="MeEmailCreateEmailCommand" />
    public required string Email { get; init; }


}