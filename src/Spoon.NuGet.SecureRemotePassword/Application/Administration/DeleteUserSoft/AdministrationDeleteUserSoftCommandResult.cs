namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.DeleteUserSoft
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class AdministrationDeleteUserSoftCommandResult
    {
        /// <inheritdoc cref="AdministrationDeleteUserSoftCommandResult" />
        public Guid UserId { get; internal set; }
        /// <inheritdoc cref="AdministrationDeleteUserSoftCommandResult" />
        public string? Email { get; internal set; }        
        /// <inheritdoc cref="AdministrationDeleteUserSoftCommandResult" />
        public string? ServerSessionProof { get; internal set; }
    }
}