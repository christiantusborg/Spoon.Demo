namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.CreateUser
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class AdministrationCreateUserCommandResult
    {
        /// <inheritdoc cref="AdministrationCreateUserCommandResult" />
        public Guid UserId { get; internal set; }
        /// <inheritdoc cref="AdministrationCreateUserCommandResult" />
        public string? Email { get; internal set; }        
        /// <inheritdoc cref="AdministrationCreateUserCommandResult" />
        public string? ServerSessionProof { get; internal set; }
    }
}