namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities;

using Core.Domain;

/// <summary>
///  Class UserEmailConfirm. This class cannot be inherited.
/// </summary>
public class UserEmailConfirm : Entity
{
    /// <inheritdoc cref="UserEmailConfirm" />
    public Guid EmailId { get; set; }
    /// <inheritdoc cref="UserEmailConfirm" />
    public required string ConfirmationToken { get; set; }
    /// <inheritdoc cref="UserEmailConfirm" />
    public DateTime CreatedAt { get; set; }
    /// <inheritdoc cref="UserEmailConfirm" />
    public UserEmail? UserEmail { get; set; }
}