namespace Spoon.NuGet.SecureRemotePassword.Application.RolesClaims.RemoveBulk
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class RoleClaimRemoveBulkCommandResult
    {
        /// <inheritdoc cref="RoleClaimRemoveBulkCommandResult" />
        public Guid UserId { get; internal set; }
        /// <inheritdoc cref="RoleClaimRemoveBulkCommandResult" />
        public string? Email { get; internal set; }        
        /// <inheritdoc cref="RoleClaimRemoveBulkCommandResult" />
        public string? ServerSessionProof { get; internal set; }
    }
}