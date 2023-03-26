namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities;

using Core.Domain;

public class UserClaim : Entity
{
    public Guid UserId { get; set; }
    public Guid ClaimId { get; set; }
    public string SignedHash { get; set; }
    public DateTime CreatedAt { get; set; }

}