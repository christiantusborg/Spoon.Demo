namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities;

using Core.Domain;
using Helpers;

public class SecureRemotePasswordByRecoveryEmail : SignedEntity<SecureRemotePasswordByRecoveryEmail>
{
    public Guid UserId { get; set; }
    public string EmailAddressHash { get; set; }
    public Guid RecoveryToken { get; set; }
    public DateTime CreatedAt { get; set; }
}