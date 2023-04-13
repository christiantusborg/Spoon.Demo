namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities;

using Core.Domain;

/// <summary>
///     Class Session. This class cannot be inherited.
/// </summary>
public sealed class Session : Entity
{
    /// <inheritdoc cref="Session" />
    public Guid UserId { get; set; }

    /// <inheritdoc cref="Session" />
    public Guid SessionId { get; set; }

    /// <inheritdoc cref="Session" />
    public required string RefreshTokenHash { get; set; }

    /// <inheritdoc cref="Session" />
    public required string IpAddressHash { get; set; }

    /// <inheritdoc cref="Session" />
    public required string UserAgentHash { get; set; }

    /// <inheritdoc cref="Session" />
    public DateTime ActionAt { get; set; }

    /// <inheritdoc cref="Session" />
    public DateTime CreatedAt { get; set; }

    /// <inheritdoc cref="Session" />
    public User User { get; set; } = null!;
}