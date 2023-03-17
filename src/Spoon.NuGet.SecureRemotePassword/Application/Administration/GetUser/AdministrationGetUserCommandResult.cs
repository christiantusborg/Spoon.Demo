namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.GetUser
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class AdministrationGetUserCommandResult
    {
        /// <inheritdoc cref="AdministrationGetUserCommandResult" />
        public Guid UserId { get; internal set; }
        /// <inheritdoc cref="AdministrationGetUserCommandResult" />
        public string? Email { get; internal set; }        
        /// <inheritdoc cref="AdministrationGetUserCommandResult" />
        public string? ServerSessionProof { get; internal set; }
    }
}