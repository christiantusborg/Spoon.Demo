namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.CreateUser
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class AdministrationCreateUserCommandResult
    {
        /// <inheritdoc cref="AdministrationCreateUserCommandResult" />
        public Guid UserId { get; internal set; }

        public Guid RecoveryToken { get; set; }
        public string EmailAddressHash { get; set; }
    }
}