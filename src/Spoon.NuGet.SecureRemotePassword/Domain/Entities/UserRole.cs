namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities;

using Core.Domain;

public class UserRole : Entity
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
    public string SignedHash { get; set; }
    public DateTime CreatedAt { get; set; }
}