namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities;

using Core.Domain;

/// <summary>
///     Class TwoFactorAuthenticationTotp. This class cannot be inherited.
/// </summary>
public sealed class TwoFactorAuthenticationTotp : Entity
{
    /// <inheritdoc cref="TwoFactorAuthenticationTotp" />
    public Guid UserId { get; set; }

    /// <inheritdoc cref="TwoFactorAuthenticationTotp" />
    public required string SecretKeyEncrypted { get; set; }

    /// <inheritdoc cref="TwoFactorAuthenticationTotp" />
    public DateTime CreatedAt { get; set; }

    /// <inheritdoc cref="TwoFactorAuthenticationTotp" />
    public DateTime UpdatedAt { get; set; }

    /// <inheritdoc cref="TwoFactorAuthenticationTotp" />
    public DateTime? DeletedAt { get; set; }

    /// <inheritdoc cref="TwoFactorAuthenticationTotp" />
    public User User { get; set; } = null!;
}