namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities;

using Core.Domain;

/// <summary>
///     Class User. This class cannot be inherited.
/// </summary>
public sealed class User : Entity
{
    /// <inheritdoc cref="User" />
    public Guid UserId { get; set; }

    /// <inheritdoc cref="User" />
    public required string UsernameHash { get; set; }

    /// <inheritdoc cref="User" />
    public DateTime? DisabledAt { get; set; }

    /// <inheritdoc cref="User" />
    public DateTime? LockoutEnd { get; set; }

    /// <inheritdoc cref="User" />
    public int LockoutCount { get; set; }

    /// <inheritdoc cref="User" />
    public DateTime? MustChangePassword { get; set; }

    /// <inheritdoc cref="User" />
    public DateTime? LastLogin { get; set; }

    /// <inheritdoc cref="User" />
    public required DateTime CreatedAt { get; set; }

    /// <inheritdoc cref="User" />
    public required DateTime UpdatedAt { get; set; }

    /// <inheritdoc cref="User" />
    public DateTime? DeletedAt { get; set; }

    /// <inheritdoc cref="User" />
    public ICollection<UserEmail> UserEmails { get; set; } = new List<UserEmail>();

    /// <inheritdoc cref="User" />
    public ICollection<Role> Roles { get; set; } = new List<Role>();

    /// <inheritdoc cref="User" />
    public ICollection<Claim> Claims { get; set; } = new List<Claim>();

    /// <inheritdoc cref="User" />
    public ICollection<SecureRemotePasswordByRecoveryCode> SecureRemotePasswordsByRecoveryCodes { get; set; } = new List<SecureRemotePasswordByRecoveryCode>();

    /// <inheritdoc cref="User" />
    public ICollection<SecureRemotePasswordByRecoveryEmail> SecureRemotePasswordByRecoveryEmails { get; set; } = new List<SecureRemotePasswordByRecoveryEmail>();

    /// <inheritdoc cref="User" />
    public ICollection<SecureRemotePasswordLogin> SecureRemotePasswordLogins { get; set; } = new List<SecureRemotePasswordLogin>();

    /// <inheritdoc cref="User" />
    public ICollection<Session>? Sessions { get; set; }

    /// <inheritdoc cref="User" />
    public TwoFactorAuthenticationTotp? TwoFactorAuthenticationTotp { get; set; }

    /// <inheritdoc cref="User" />
    public ICollection<UserAllowedIpAccess> UserAllowedIpAccess { get; set; } = new List<UserAllowedIpAccess>();

    /// <inheritdoc cref="User" />
    // ReSharper disable once CollectionNeverUpdated.Global
    public ICollection<UserLoginHistory> UserLoginHistories { get; set; } = new List<UserLoginHistory>();
}