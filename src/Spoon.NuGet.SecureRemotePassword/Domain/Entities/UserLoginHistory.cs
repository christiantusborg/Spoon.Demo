namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities;

using Core.Domain;
using Helpers;

public class UserLoginHistory : Entity
{
    public Guid UserLoginHistoryId { get; set; }
    public Guid UserId { get; set; }
    public string IpAddressHash { get; set; }
    public string IpAddressEncrypted { get; set; }
    public string UserAgentHash { get; set; }
    public bool IsSuccess { get; set; }
    public DateTime CreatedAt { get; set; }
    public User User { get; set; }
}