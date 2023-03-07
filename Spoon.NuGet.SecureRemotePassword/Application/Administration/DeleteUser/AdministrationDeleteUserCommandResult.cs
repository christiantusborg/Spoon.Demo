namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.DeleteUser
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class AdministrationDeleteUserCommandResult
    {
        /// <inheritdoc cref="AdministrationDeleteUserCommandResult" />
        public Guid UserId { get; internal set; }
        /// <inheritdoc cref="AdministrationDeleteUserCommandResult" />
        public string? Email { get; internal set; }        
        /// <inheritdoc cref="AdministrationDeleteUserCommandResult" />
        public string? ServerSessionProof { get; internal set; }
    }
}