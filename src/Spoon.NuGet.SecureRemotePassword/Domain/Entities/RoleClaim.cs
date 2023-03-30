namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities;

using Core.Domain;
using Helpers;

public class RoleClaim : Entity
{
    public Guid RoleId { get; set; }
    public Guid ClaimId { get; set; }
    public DateTime CreatedAt { get; set; }
}