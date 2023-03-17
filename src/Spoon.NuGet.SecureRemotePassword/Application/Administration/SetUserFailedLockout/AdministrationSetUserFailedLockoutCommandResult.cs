namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.SetUserFailedLockout
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class AdministrationSetUserFailedLockoutCommandResult
    {
        /// <inheritdoc cref="AdministrationSetUserFailedLockoutCommandResult" />
        public Guid UserId { get; internal set; }
        /// <inheritdoc cref="AdministrationSetUserFailedLockoutCommandResult" />
        public string? Email { get; internal set; }        
        /// <inheritdoc cref="AdministrationSetUserFailedLockoutCommandResult" />
        public string? ServerSessionProof { get; internal set; }
    }
}