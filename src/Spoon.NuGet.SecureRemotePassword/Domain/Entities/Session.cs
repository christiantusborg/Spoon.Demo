// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities;

using Core.Domain;

/// <summary>
///     Class Session. This class cannot be inherited.
/// </summary>
public sealed class Session : Entity
{
    /// <inheritdoc cref="Session" />
    public required Guid UserId { get; set; }

    /// <inheritdoc cref="Session" />
    public required Guid SessionId { get; set; }

    /// <inheritdoc cref="Session" />
    public DateTime SessionExpiresAt { get; set; }
    
    /// <inheritdoc cref="Session" />
    public required string RefreshTokenHashed { get; set; }
    
    /// <inheritdoc cref="Session" />
    public DateTime RefreshTokenExpiresAt { get; set; }
    
    /// <inheritdoc cref="Session" />
    public required string IpAddressEncrypted { get; set; }

    /// <inheritdoc cref="Session" />
    public required string UserAgentEncrypted { get; set; }

    /// <inheritdoc cref="Session" />
    public DateTime ActionAt { get; set; }

    /// <inheritdoc cref="Session" />
    public DateTime CreatedAt { get; set; }

    /// <inheritdoc cref="Session" />
    public DateTime UpdatedAt { get; set; }
    
    /// <inheritdoc cref="Session" />
    public User User { get; set; } = null!;
    
}