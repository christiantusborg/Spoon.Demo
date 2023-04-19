// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Users.UserGetLoginChallenge;

using Core.Application;
using Core.Application.Interfaces;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
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

    /// <inheritdoc cref="UserGetLoginChallengeCommand" />
    public required string UsernameHashed { get; set; }
}