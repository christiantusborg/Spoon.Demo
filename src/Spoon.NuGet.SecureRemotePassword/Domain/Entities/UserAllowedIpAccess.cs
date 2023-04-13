namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities;

using Core.Domain;
using Helpers;

/// <summary>
///   Class UserAllowedIpAccess. This class cannot be inherited.
/// </summary>
public sealed class UserAllowedIpAccess : Entity
{
    /// <inheritdoc cref="UserAllowedIpAccess" />
    public Guid UserId { get; set; }
    /// <inheritdoc cref="UserAllowedIpAccess" />
    public required string IpAddressHash { get; set; }
    /// <inheritdoc cref="UserAllowedIpAccess" />
    public required string IpAddressEncrypted { get; set; }
    /// <inheritdoc cref="UserAllowedIpAccess" />
    public DateTime CreatedAt { get; set; }
    /// <inheritdoc cref="UserAllowedIpAccess" />
    public IEnumerable<User> Users { get; set;} = null!;
}