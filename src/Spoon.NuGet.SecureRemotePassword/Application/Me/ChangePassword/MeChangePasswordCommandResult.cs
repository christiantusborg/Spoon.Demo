namespace Spoon.NuGet.SecureRemotePassword.Application.Me.ChangePassword
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class MeChangePasswordCommandResult
    {
        /// <inheritdoc cref="MeChangePasswordCommandResult" />
        public Guid UserId { get; internal set; }
        /// <inheritdoc cref="MeChangePasswordCommandResult" />
        public string? ServerSessionProof { get; internal set; }
    }
}