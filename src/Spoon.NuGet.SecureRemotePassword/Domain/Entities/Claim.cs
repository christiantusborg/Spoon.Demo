namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities;

using Core.Domain;

public class Claim : Entity
{
    public Guid ClaimId { get; set; }
    public string Name { get; set; }
    public string SignedHash { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}