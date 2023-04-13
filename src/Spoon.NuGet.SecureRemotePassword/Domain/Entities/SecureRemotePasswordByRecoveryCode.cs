namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities;

using Core.Domain;

/// <summary>
///     Class SecureRemotePasswordByRecoveryCode. This class cannot be inherited.
/// </summary>
public sealed class SecureRemotePasswordByRecoveryCode : Entity
{
    /// <inheritdoc cref="SecureRemotePasswordByRecoveryCode" />
    public Guid UserId { get; set; }

    /// <inheritdoc cref="SecureRemotePasswordByRecoveryCode" />
    public required string VerifierEncrypted { get; set; }

    /// <inheritdoc cref="SecureRemotePasswordByRecoveryCode" />
    public required string SaltEncrypted { get; set; }

    /// <inheritdoc cref="SecureRemotePasswordByRecoveryCode" />
    public DateTime CreatedAt { get; set; }

    /// <inheritdoc cref="SecureRemotePasswordByRecoveryCode" />
    public User User { get; set; } = null!;
}