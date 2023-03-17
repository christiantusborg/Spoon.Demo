namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.SetUserMustChangePassword
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class AdministrationSetUserMustChangePasswordCommandResult
    {
        /// <inheritdoc cref="AdministrationSetUserMustChangePasswordCommandResult" />
        public Guid UserId { get; internal set; }
        /// <inheritdoc cref="AdministrationSetUserMustChangePasswordCommandResult" />
        public string? Email { get; internal set; }        
        /// <inheritdoc cref="AdministrationSetUserMustChangePasswordCommandResult" />
        public string? ServerSessionProof { get; internal set; }
    }
}