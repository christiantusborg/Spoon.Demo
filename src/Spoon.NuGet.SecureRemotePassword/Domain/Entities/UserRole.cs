namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities;

using Core.Domain;
using Helpers;

public class UserRole : SignedEntity
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
    public DateTime CreatedAt { get; set; }
}