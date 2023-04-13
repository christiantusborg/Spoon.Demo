// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.SetUserEmailVerified
{
    /// <summary>
    /// The result of adding an email address to a user account in the Secure Remote Password application.
    /// </summary>
    public sealed class AdministrationSetUserEmailVerifiedCommandResult
    {
        /// <inheritdoc cref="AdministrationSetUserEmailVerifiedCommandResult" />
        public bool Success { get; internal set; }
    }
}