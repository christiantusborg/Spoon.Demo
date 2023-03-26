namespace Spoon.NuGet.SecureRemotePassword.Application.Role.Get
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class RoleGetCommandResult
    {
        /// <inheritdoc cref="RoleGetCommandResult" />
        public Guid UserId { get; internal set; }
        /// <inheritdoc cref="RoleGetCommandResult" />
        public string? Email { get; internal set; }        
        /// <inheritdoc cref="RoleGetCommandResult" />
        public string? ServerSessionProof { get; internal set; }
    }
}