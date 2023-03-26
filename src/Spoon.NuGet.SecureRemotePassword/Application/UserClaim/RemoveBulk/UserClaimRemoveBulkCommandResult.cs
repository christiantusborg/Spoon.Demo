namespace Spoon.NuGet.SecureRemotePassword.Application.UserClaim.RemoveBulk
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class UserClaimRemoveBulkCommandResult
    {
        /// <inheritdoc cref="UserClaimRemoveBulkCommandResult" />
        public Guid UserId { get; internal set; }
        /// <inheritdoc cref="UserClaimRemoveBulkCommandResult" />
        public string? Email { get; internal set; }        
        /// <inheritdoc cref="UserClaimRemoveBulkCommandResult" />
        public string? ServerSessionProof { get; internal set; }
    }
}