namespace Spoon.NuGet.SecureRemotePassword.Application.UserRole.AddBulk
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class UserRoleAddBulkCommandResult
    {
        /// <inheritdoc cref="UserRoleAddBulkCommandResult" />
        public Guid UserId { get; internal set; }
        /// <inheritdoc cref="UserRoleAddBulkCommandResult" />
        public string? Email { get; internal set; }        
        /// <inheritdoc cref="UserRoleAddBulkCommandResult" />
        public string? ServerSessionProof { get; internal set; }
    }
}