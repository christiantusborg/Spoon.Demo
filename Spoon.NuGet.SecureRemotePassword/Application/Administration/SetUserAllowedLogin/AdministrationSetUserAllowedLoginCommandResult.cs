namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.SetUserAllowedLogin
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class AdministrationSetUserAllowedLoginCommandResult
    {
        /// <inheritdoc cref="AdministrationSetUserAllowedLoginCommandResult" />
        public Guid UserId { get; internal set; }
        /// <inheritdoc cref="AdministrationSetUserAllowedLoginCommandResult" />
        public string? Email { get; internal set; }        
        /// <inheritdoc cref="AdministrationSetUserAllowedLoginCommandResult" />
        public string? ServerSessionProof { get; internal set; }
    }
}