// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Users.UserSubmitLoginChallenge;

/// <summary>
///     Class ProductCreateQueryResult. This class cannot be inherited.
/// </summary>
public sealed class UserSubmitLoginChallengeCommandResult
{
    /// <inheritdoc cref="UserSubmitLoginChallengeCommandResult" />
    public required string AccessToken { get; set; }

    /// <inheritdoc cref="UserSubmitLoginChallengeCommandResult" />
    public required string RefreshToken { get; set; }

    /// <inheritdoc cref="UserSubmitLoginChallengeCommandResult" />
    public int ExpiresIn { get; set; }
}