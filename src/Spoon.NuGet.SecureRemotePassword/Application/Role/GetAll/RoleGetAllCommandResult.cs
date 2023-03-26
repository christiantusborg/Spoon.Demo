namespace Spoon.NuGet.SecureRemotePassword.Application.Role.GetAll
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class RoleGetAllCommandResult
    {
        /// <inheritdoc cref="RoleGetAllCommandResult" />
        public Guid UserId { get; internal set; }
        /// <inheritdoc cref="RoleGetAllCommandResult" />
        public string? Email { get; internal set; }        
        /// <inheritdoc cref="RoleGetAllCommandResult" />
        public string? ServerSessionProof { get; internal set; }
    }
}