namespace Spoon.NuGet.SecureRemotePassword.Application.Me.VerifyChallenge;

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
public sealed class MeVerifyChallengeGetCommand : MediatorBaseCommand, IHandleableRequest<MeVerifyChallengeGetCommand,
    MeVerifyChallengeGetCommandHandler, Either<MeVerifyChallengeGetCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MeVerifyChallengeGetCommand" /> class.
    /// </summary>
    public MeVerifyChallengeGetCommand()
        : base(typeof(MeVerifyChallengeGetCommand))
    {
    }
    /// <inheritdoc cref="MeVerifyChallengeGetCommand" />
    public Guid UserId { get; set; }
}