// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Me.Session.GetAll
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class SessionGetAllCommandResult
    {
        /// <inheritdoc cref="Session" />
        public DateTime SessionId { get; set; }
        
        /// <inheritdoc cref="Session" />
        public DateTime SessionExpiresAt { get; set; }
   
        /// <inheritdoc cref="Session" />
        public DateTime RefreshTokenExpiresAt { get; set; }
    
        /// <inheritdoc cref="Session" />
        public required string IpAddressDecrypted { get; set; }

        /// <inheritdoc cref="Session" />
        public required string UserAgentDecrypted { get; set; }

        /// <inheritdoc cref="Session" />
        public DateTime ActionAt { get; set; }

    }
}