namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.RemoveUserEmail
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class AdministrationRemoveUserEmailCommandResult
    {
        /// <inheritdoc cref="AdministrationRemoveUserEmailCommandResult" />
        public Guid UserId { get; internal set; }
        /// <inheritdoc cref="AdministrationRemoveUserEmailCommandResult" />
        public string? Email { get; internal set; }        
        /// <inheritdoc cref="AdministrationRemoveUserEmailCommandResult" />
        public string? ServerSessionProof { get; internal set; }
    }
}