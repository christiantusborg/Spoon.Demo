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

        public SrpEphemeral? Challenge { get; set; }
        public string Salt { get; set; }
    }
}