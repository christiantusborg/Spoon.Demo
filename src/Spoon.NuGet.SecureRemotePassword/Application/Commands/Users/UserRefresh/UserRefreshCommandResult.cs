// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Users.UserRefresh
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class UserRefreshCommandResult
    {
        /// <inheritdoc cref="UserRefreshCommandResult" />
        public required string AccessToken { get; set; }
        /// <inheritdoc cref="UserRefreshCommandResult" />
        public required string RefreshToken { get; set; }
        /// <inheritdoc cref="UserRefreshCommandResult" />
        public int ExpiresIn { get; set; }
    }
}