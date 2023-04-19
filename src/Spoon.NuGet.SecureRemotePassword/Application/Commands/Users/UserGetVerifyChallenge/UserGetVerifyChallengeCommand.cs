namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Users.UserGetVerifyChallenge;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class UserGetVerifyChallengeCommand : MediatorBaseCommand, IHandleableRequest<UserGetVerifyChallengeCommand,
    UserGetVerifyChallengeCommandHandler, Either<UserGetVerifyChallengeCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserGetVerifyChallengeCommand" /> class.
    /// </summary>
    public UserGetVerifyChallengeCommand()
        : base(typeof(UserGetVerifyChallengeCommand))
    {
    }

    /// <inheritdoc cref="UserGetVerifyChallengeCommand" />
    public Guid UserId { get; set; }
}