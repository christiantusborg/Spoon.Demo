namespace Spoon.NuGet.SecureRemotePassword.Application.RolesClaims.AddBulk
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class RoleClaimAddBulkCommandResult
    {
        /// <inheritdoc cref="RoleClaimAddBulkCommandResult" />
        public Guid UserId { get; internal set; }
        /// <inheritdoc cref="RoleClaimAddBulkCommandResult" />
        public string? Email { get; internal set; }        
        /// <inheritdoc cref="RoleClaimAddBulkCommandResult" />
        public string? ServerSessionProof { get; internal set; }
    }
}