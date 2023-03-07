namespace Spoon.NuGet.SecureRemotePassword.Application.Me.Email.Get
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class MeEmailGetCommandResult
    {
        /// <inheritdoc cref="MeEmailGetCommandResult" />
        public Guid UserId { get; internal set; }
        /// <inheritdoc cref="MeEmailGetCommandResult" />
        public string? Email { get; internal set; }        
        /// <inheritdoc cref="MeEmailGetCommandResult" />
        public string? ServerSessionProof { get; internal set; }
    }
}