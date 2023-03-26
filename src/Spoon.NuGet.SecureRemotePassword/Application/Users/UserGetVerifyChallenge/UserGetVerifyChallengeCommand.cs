namespace Spoon.NuGet.SecureRemotePassword.Application.Users.UserGetVerifyChallenge;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
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
    
    public required string Username { get; set; }
}