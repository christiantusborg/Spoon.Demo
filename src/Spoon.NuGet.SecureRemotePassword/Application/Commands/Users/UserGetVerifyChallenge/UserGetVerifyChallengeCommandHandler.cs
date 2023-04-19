namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Users.UserGetVerifyChallenge;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class UserGetVerifyChallengeCommandHandler : IRequestHandler<UserGetVerifyChallengeCommand, Either<UserGetVerifyChallengeCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UserGetVerifyChallengeCommandHandler" /> class.
    /// </summary>
    public UserGetVerifyChallengeCommandHandler()
    {
    }

    /// <summary>
    ///     Handles the specified request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="cancellationToken">
    ///     The cancellation token that can be used by other objects or threads to receive notice
    ///     of cancellation.
    /// </param>
    /// <returns>Task&lt;Either&lt;ProductCreateQueryResult&gt;&gt;.</returns>
    public async Task<Either<UserGetVerifyChallengeCommandResult>> Handle(
        UserGetVerifyChallengeCommand request,
        CancellationToken cancellationToken)
    {
        // Your method logic here
        await Task.CompletedTask;

        return new Either<UserGetVerifyChallengeCommandResult>(new UserGetVerifyChallengeCommandResult());
    }
}