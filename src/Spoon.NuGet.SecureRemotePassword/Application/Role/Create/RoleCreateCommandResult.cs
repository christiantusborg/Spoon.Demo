namespace Spoon.NuGet.SecureRemotePassword.Application.Role.Create
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class RoleCreateCommandResult
    {
        /// <inheritdoc cref="RoleCreateCommandResult" />
        public Guid UserId { get; internal set; }
        /// <inheritdoc cref="RoleCreateCommandResult" />
        public string? Email { get; internal set; }        
        /// <inheritdoc cref="RoleCreateCommandResult" />
        public string? ServerSessionProof { get; internal set; }
    }
}