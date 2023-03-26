namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities;

using Core.Domain;

public class SecureRemotePasswordLogin : Entity
{
    public Guid UserId { get; set; }
    public string Verifier { get; set; }
    public string Salt { get; set; }
    public string SignedHash { get; set; }
    public DateTime UpdatedAt { get; set; }
}