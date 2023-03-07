namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.AddUserEmail
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class AdministrationAddUserEmailCommandResult
    {
        /// <inheritdoc cref="AdministrationAddUserEmailCommandResult" />
        public Guid UserId { get; internal set; }
        /// <inheritdoc cref="AdministrationAddUserEmailCommandResult" />
        public string? Email { get; internal set; }        
        /// <inheritdoc cref="AdministrationAddUserEmailCommandResult" />
        public string? ServerSessionProof { get; internal set; }
    }
}