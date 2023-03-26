namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities;

using Core.Domain;
using Helpers;

public class SecureRemotePasswordByRecoveryCode : SignedEntity<SecureRemotePasswordByRecoveryCode>
{
    public Guid UserId { get; set; }
    public string Verifier { get; set; }
    public string Salt { get; set; }
    public DateTime CreatedAt { get; set; }
}