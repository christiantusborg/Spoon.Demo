// ReSharper disable PropertyCanBeMadeInitOnly.Global

namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Me.VerifyChallenge;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
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