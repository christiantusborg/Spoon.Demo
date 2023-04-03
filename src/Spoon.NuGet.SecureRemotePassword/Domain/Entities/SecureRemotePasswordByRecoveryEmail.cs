namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities;

using Core.Domain;
using Helpers;

public class SecureRemotePasswordByRecoveryEmail : Entity
{
    public Guid UserId { get; set; }
    public string EmailAddressHash { get; set; }
    public string RecoveryTokenHash { get; set; }
    public DateTime CreatedAt { get; set; }
    public virtual User? User { get; set; }
}