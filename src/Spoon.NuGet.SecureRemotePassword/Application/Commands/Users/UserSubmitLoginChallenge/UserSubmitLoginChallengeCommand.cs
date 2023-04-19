namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Users.UserSubmitLoginChallenge;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
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

    /// <summary>
    ///     Gets or sets the challenge.
    /// </summary>
    public Guid UserId { get; init; }

    public required string IpAddress { get; set; }
    public required string UserAgent { get; set; }
}