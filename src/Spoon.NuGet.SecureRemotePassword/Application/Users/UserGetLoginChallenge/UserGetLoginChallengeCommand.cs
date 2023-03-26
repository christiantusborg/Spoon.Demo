namespace Spoon.NuGet.SecureRemotePassword.Application.Users.UserGetLoginChallenge;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
public sealed class UserGetLoginChallengeCommand : MediatorBaseCommand, IHandleableRequest<UserGetLoginChallengeCommand,
    UserGetLoginChallengeCommandHandler, Either<UserGetLoginChallengeCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserGetLoginChallengeCommand" /> class.
    /// </summary>
    public UserGetLoginChallengeCommand()
        : base(typeof(UserGetLoginChallengeCommand))
    {
    
    }
    
    public required string Username { get; set; }
}