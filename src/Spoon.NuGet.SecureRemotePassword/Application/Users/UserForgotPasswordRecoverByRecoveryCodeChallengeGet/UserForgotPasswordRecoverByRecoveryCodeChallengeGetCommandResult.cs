namespace Spoon.NuGet.SecureRemotePassword.Application.Users.UserForgotPasswordRecoverByRecoveryCodeChallengeGet
{
    using global::SecureRemotePassword;

    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class UserForgotPasswordRecoverByRecoveryCodeChallengeGetCommandResult
    {
        /// <inheritdoc cref="UserForgotPasswordRecoverByRecoveryCodeChallengeGetCommandResult" />
        public Guid UserId { get; set; }

        /// <inheritdoc cref="UserForgotPasswordRecoverByRecoveryCodeChallengeGetCommandResult" />
        public SrpEphemeral? Challenge { get; set; }
        
        /// <inheritdoc cref="UserForgotPasswordRecoverByRecoveryCodeChallengeGetCommandResult" />
        public required string Salt { get; set; }
    }
}