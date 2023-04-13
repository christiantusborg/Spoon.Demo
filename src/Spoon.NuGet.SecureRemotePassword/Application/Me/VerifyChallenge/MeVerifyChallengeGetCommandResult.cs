// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Spoon.NuGet.SecureRemotePassword.Application.Me.VerifyChallenge
{
    using global::SecureRemotePassword;

    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class MeVerifyChallengeGetCommandResult
    {
        /// <inheritdoc cref="MeVerifyChallengeGetCommandResult" />
        public Guid UserId { get; set; }

        /// <inheritdoc cref="MeVerifyChallengeGetCommandResult" />
        public SrpEphemeral? Challenge { get; set; }
        
        /// <inheritdoc cref="MeVerifyChallengeGetCommandResult" />
        public required string Salt { get; set; }
    }
}