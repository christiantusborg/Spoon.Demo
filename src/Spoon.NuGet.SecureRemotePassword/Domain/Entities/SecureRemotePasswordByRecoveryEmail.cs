namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities;

using Core.Domain;

/// <summary>
///     Class SecureRemotePasswordByRecoveryEmail. This class cannot be inherited.
/// </summary>
public sealed class SecureRemotePasswordByRecoveryEmail : Entity
{
    /// <inheritdoc cref="SecureRemotePasswordByRecoveryEmail" />
    public Guid UserId { get; set; }

    /// <inheritdoc cref="SecureRemotePasswordByRecoveryEmail" />
    public required string EmailAddressHashed { get; set; }

    /// <inheritdoc cref="SecureRemotePasswordByRecoveryEmail" />
    public required string RecoveryTokenHashed { get; set; }

    /// <inheritdoc cref="SecureRemotePasswordByRecoveryEmail" />
    public DateTime CreatedAt { get; set; }

    /// <inheritdoc cref="SecureRemotePasswordByRecoveryEmail" />
    public User? User { get; set; } = null!;
}