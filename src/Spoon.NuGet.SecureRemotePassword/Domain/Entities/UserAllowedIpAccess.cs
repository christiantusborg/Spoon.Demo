namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities;

using Core.Domain;

public class UserAllowedIpAccess : Entity
{
    public Guid UserId { get; set; }
    public string IpAddress { get; set; }
    public string SignedHash { get; set; }
    public DateTime CreatedAt { get; set; }
}