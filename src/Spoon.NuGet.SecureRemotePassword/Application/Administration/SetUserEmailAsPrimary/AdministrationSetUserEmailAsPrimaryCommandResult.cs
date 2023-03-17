namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.SetUserEmailAsPrimary
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class AdministrationSetUserEmailAsPrimaryCommandResult
    {
        /// <inheritdoc cref="AdministrationSetUserEmailAsPrimaryCommandResult" />
        public Guid UserId { get; internal set; }
        /// <inheritdoc cref="AdministrationSetUserEmailAsPrimaryCommandResult" />
        public string? Email { get; internal set; }        
        /// <inheritdoc cref="AdministrationSetUserEmailAsPrimaryCommandResult" />
        public string? ServerSessionProof { get; internal set; }
    }
}