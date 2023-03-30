namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities;

using Core.Domain;
using Helpers;

public class UserClaim : SignedEntity
{
    public Guid UserId { get; set; }
    public Guid ClaimId { get; set; }
    public DateTime CreatedAt { get; set; }

}