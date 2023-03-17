namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.SetUserPassword
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class AdministrationSetUserPasswordCommandResult
    {
        /// <inheritdoc cref="AdministrationSetUserPasswordCommandResult" />
        public Guid UserId { get; internal set; }
        /// <inheritdoc cref="AdministrationSetUserPasswordCommandResult" />
        public string? Email { get; internal set; }        
        /// <inheritdoc cref="AdministrationSetUserPasswordCommandResult" />
        public string? ServerSessionProof { get; internal set; }
    }
}