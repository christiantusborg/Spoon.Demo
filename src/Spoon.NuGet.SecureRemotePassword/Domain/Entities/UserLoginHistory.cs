namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities;

using Core.Domain;
using Helpers;

/// <summary>
///   Class UserLoginHistory. This class cannot be inherited.
/// </summary>
public class UserLoginHistory : Entity
{
    /// <inheritdoc cref="UserLoginHistory" />
    public Guid UserLoginHistoryId { get; set; }
    /// <inheritdoc cref="UserLoginHistory" />
    public Guid UserId { get; set; }
    /// <inheritdoc cref="UserLoginHistory" />
    public required string IpAddressHash { get; set; }
    /// <inheritdoc cref="UserLoginHistory" />
    public required string IpAddressEncrypted { get; set; }
    /// <inheritdoc cref="UserLoginHistory" />
    public required string UserAgentHash { get; set; }
    /// <inheritdoc cref="UserLoginHistory" />
    public bool IsSuccess { get; set; }
    /// <inheritdoc cref="UserLoginHistory" />
    public DateTime CreatedAt { get; set; }
    /// <inheritdoc cref="UserLoginHistory" />
    public User? User { get; set; }
}