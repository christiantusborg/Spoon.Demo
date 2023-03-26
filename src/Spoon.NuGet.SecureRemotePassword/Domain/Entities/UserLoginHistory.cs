namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities;

using Core.Domain;

public class UserLoginHistory : Entity
{
    public Guid UserId { get; set; }
    public string IpAddressHash { get; set; }
    public string IpAddressEncrypted { get; set; }
    public string UserAgentHash { get; set; }
    public string SignedHash { get; set; }
    public bool IsSuccess { get; set; }
    public DateTime CreatedAt { get; set; }
}