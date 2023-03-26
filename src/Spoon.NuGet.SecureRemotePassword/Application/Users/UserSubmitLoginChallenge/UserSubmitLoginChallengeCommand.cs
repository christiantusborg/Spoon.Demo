namespace Spoon.NuGet.SecureRemotePassword.Application.Users.UserSubmitLoginChallenge;

using Spoon.NuGet.EitherCore;
using Spoon.NuGet.Mediator;
using Spoon.NuGet.Mediator.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
public sealed class UserSubmitLoginChallengeCommand : MediatorBaseCommand, IHandleableRequest<UserSubmitLoginChallengeCommand,
    UserSubmitLoginChallengeCommandHandler, Either<UserSubmitLoginChallengeCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserSubmitLoginChallengeCommand" /> class.
    /// </summary>
    public UserSubmitLoginChallengeCommand()
        : base(typeof(UserSubmitLoginChallengeCommand))
    {
    
    }
    
    public Guid UserId {internal get; set; }
    public string ClientSessionProof { internal get; set; }

}