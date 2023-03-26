namespace Spoon.NuGet.SecureRemotePassword.Application.UserClaim.AddBulk
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class UserClaimAddBulkCommandResult
    {
        /// <inheritdoc cref="UserClaimAddBulkCommandResult" />
        public Guid UserId { get; internal set; }
        /// <inheritdoc cref="UserClaimAddBulkCommandResult" />
        public string? Email { get; internal set; }        
        /// <inheritdoc cref="UserClaimAddBulkCommandResult" />
        public string? ServerSessionProof { get; internal set; }
    }
}