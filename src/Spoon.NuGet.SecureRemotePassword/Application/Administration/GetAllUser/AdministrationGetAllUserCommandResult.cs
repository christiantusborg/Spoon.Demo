namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.GetAllUser
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class AdministrationGetAllUserCommandResult
    {
        /// <inheritdoc cref="AdministrationGetAllUserCommandResult" />
        public Guid UserId { get; internal set; }
        /// <inheritdoc cref="AdministrationGetAllUserCommandResult" />
        public string? Email { get; internal set; }        
        /// <inheritdoc cref="AdministrationGetAllUserCommandResult" />
        public string? ServerSessionProof { get; internal set; }
    }
}