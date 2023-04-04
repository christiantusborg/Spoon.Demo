namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities;

using Core.Domain;
using Helpers;

/// <summary>
/// Represents a claim that can be assigned to a user or role.
/// </summary>
public class Claim : Entity
{
    /// <summary>
    /// Gets or sets the unique identifier of the claim.
    /// </summary>
    public Guid ClaimId { get; set; }

    /// <summary>
    /// Gets or sets the name of the claim.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the claim was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the claim was last updated.
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the claim was deleted, or null if it has not been deleted.
    /// </summary>
    public DateTime? DeletedAt { get; set; }

    /// <summary>
    /// Gets or sets the users that have been assigned this claim.
    /// </summary>
    public virtual IEnumerable<User>? Users { get; set; }

    /// <summary>
    /// Gets or sets the roles that have been assigned this claim.
    /// </summary>
    public virtual IEnumerable<Role>? Roles { get; set; }
}