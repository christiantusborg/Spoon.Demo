namespace Spoon.NuGet.SecureRemotePassword.Application.Roles.DeleteSoft
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class RoleDeleteSoftCommandResult
    {
        /// <inheritdoc cref="RoleDeleteSoftCommandResult" />
        public Guid UserId { get; internal set; }
        /// <inheritdoc cref="RoleDeleteSoftCommandResult" />
        public string? Email { get; internal set; }        
        /// <inheritdoc cref="RoleDeleteSoftCommandResult" />
        public string? ServerSessionProof { get; internal set; }
    }
}