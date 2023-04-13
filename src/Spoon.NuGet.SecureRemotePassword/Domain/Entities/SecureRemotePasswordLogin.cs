namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities;

using Core.Domain;

/// <summary>
///     Class SecureRemotePasswordLogin. This class cannot be inherited.
/// </summary>
public sealed class SecureRemotePasswordLogin : Entity
{
    /// <inheritdoc cref="SecureRemotePasswordLogin" />
    public Guid UserId { get; set; }

    /// <inheritdoc cref="SecureRemotePasswordLogin" />
    public required string VerifierEncrypted { get; set; }

    /// <inheritdoc cref="SecureRemotePasswordLogin" />
    public required string SaltEncrypted { get; set; }

    /// <inheritdoc cref="SecureRemotePasswordLogin" />

    public DateTime UpdatedAt { get; set; }

    /// <inheritdoc cref="SecureRemotePasswordLogin" />
    public User User { get; set; } = null!;
}