namespace Spoon.NuGet.SecureRemotePassword.Application.Roles.Update
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class RoleUpdateCommandResult
    {
        /// <inheritdoc cref="RoleUpdateCommandResult" />
        public Guid UserId { get; internal set; }
        /// <inheritdoc cref="RoleUpdateCommandResult" />
        public string? Email { get; internal set; }        
        /// <inheritdoc cref="RoleUpdateCommandResult" />
        public string? ServerSessionProof { get; internal set; }
    }
}