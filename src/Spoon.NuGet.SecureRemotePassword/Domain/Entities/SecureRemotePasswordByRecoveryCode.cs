namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities;

using Core.Domain;
using Helpers;

public class SecureRemotePasswordByRecoveryCode : Entity
{
    public Guid UserId { get; set; }
    public string VerifierEncrypted { get; set; }
    public string SaltEncrypted { get; set; }
    public DateTime CreatedAt { get; set; }
}