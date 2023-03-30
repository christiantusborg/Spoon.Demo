namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities;

using Core.Domain;
using Helpers;

public class UserAllowedIpAccess : Entity
{
    public Guid UserId { get; set; }
    public string IpAddressHash { get; set; }
    public string IpAddressEncrypted { get; set; }
    public DateTime CreatedAt { get; set; }
}