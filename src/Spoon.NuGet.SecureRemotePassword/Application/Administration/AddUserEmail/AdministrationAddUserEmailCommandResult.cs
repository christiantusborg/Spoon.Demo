// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.AddUserEmail
{
    /// <summary>
    /// The result of adding an email address to a user account in the Secure Remote Password application.
    /// </summary>
    public sealed class AdministrationAddUserEmailCommandResult
    {
        /// <summary>
        /// Gets or internal sets the ID of the newly added email address.
        /// </summary>
        public Guid EmailId { get; internal set; }
    }
}