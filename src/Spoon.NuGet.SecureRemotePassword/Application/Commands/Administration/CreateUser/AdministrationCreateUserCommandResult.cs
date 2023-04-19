// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Administration.CreateUser
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class AdministrationCreateUserCommandResult
    {
        /// <inheritdoc cref="AdministrationCreateUserCommandResult" />
        public Guid UserId { get; internal set; }

        /// <inheritdoc cref="AdministrationCreateUserCommandResult" />
        public Guid RecoveryToken { get; set; }
        
        /// <inheritdoc cref="AdministrationCreateUserCommandResult" />
        public required string EmailAddressHash { get; set; }
    }
}