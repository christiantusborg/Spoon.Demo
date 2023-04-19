// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Users.UserGetLoginChallenge;

using global::SecureRemotePassword;

/// <summary>
///     Class ProductCreateQueryResult. This class cannot be inherited.
/// </summary>
public sealed class UserGetLoginChallengeCommandResult
{
    /// <inheritdoc cref="UserGetLoginChallengeCommandResult" />
    public Guid UserId { get; set; }

    /// <inheritdoc cref="UserGetLoginChallengeCommandResult" />
    public SrpEphemeral? Challenge { get; set; }

    /// <inheritdoc cref="UserGetLoginChallengeCommandResult" />
    public required string Salt { get; set; }
}