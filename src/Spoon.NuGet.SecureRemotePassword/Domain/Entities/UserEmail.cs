namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities;

using Core.Domain;

/// <summary>
///     Class UserEmail. This class cannot be inherited.
/// </summary>
public sealed class UserEmail : Entity
{
    /// <inheritdoc cref="UserEmail" />
    public Guid UserId { get; set; }

    /// <inheritdoc cref="UserEmail" />
    public Guid EmailId { get; set; }

    /// <inheritdoc cref="UserEmail" />
    public required string EmailAddressHash { get; set; }

    /// <inheritdoc cref="UserEmail" />
    public required string EmailAddressEncrypted { get; set; }

    /// <inheritdoc cref="UserEmail" />
    public DateTime? EmailAddressVerifiedAt { get; set; }

    /// <inheritdoc cref="UserEmail" />
    public int IsPrimary { get; set; }

    /// <inheritdoc cref="UserEmail" />
    public DateTime CreatedAt { get; set; }

    /// <inheritdoc cref="UserEmail" />
    public DateTime UpdatedAt { get; set; }

    /// <inheritdoc cref="UserEmail" />
    public DateTime? DeletedAt { get; set; }

    /// <inheritdoc cref="UserEmail" />
    public User? User { get; set; }

    /// <inheritdoc cref="UserEmail" />
    public IEnumerable<UserEmailConfirm>? UserEmailConfirms { get; set; }
}