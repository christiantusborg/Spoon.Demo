namespace Spoon.NuGet.SecureRemotePassword.Application.UserRole.RemoveBulk
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class UserRoleRemoveBulkCommandResult
    {
        /// <inheritdoc cref="UserRoleRemoveBulkCommandResult" />
        public Guid UserId { get; internal set; }
        /// <inheritdoc cref="UserRoleRemoveBulkCommandResult" />
        public string? Email { get; internal set; }        
        /// <inheritdoc cref="UserRoleRemoveBulkCommandResult" />
        public string? ServerSessionProof { get; internal set; }
    }
}