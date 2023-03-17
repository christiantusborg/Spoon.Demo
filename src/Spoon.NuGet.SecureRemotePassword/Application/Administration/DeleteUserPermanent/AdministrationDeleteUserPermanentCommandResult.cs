namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.DeleteUserPermanent
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class AdministrationDeleteUserPermanentCommandResult
    {
        /// <inheritdoc cref="AdministrationDeleteUserPermanentCommandResult" />
        public Guid UserId { get; internal set; }
        /// <inheritdoc cref="AdministrationDeleteUserPermanentCommandResult" />
        public string? Email { get; internal set; }        
        /// <inheritdoc cref="AdministrationDeleteUserPermanentCommandResult" />
        public string? ServerSessionProof { get; internal set; }
    }
}