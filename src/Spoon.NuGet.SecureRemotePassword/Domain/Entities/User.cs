namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities;

using Core.Domain;

public class User : Entity
{
    public Guid UserId { get; set; }
    public DateTime? DisabledAt { get; set; }
    public DateTime? LockoutEnd { get; set; }
    public int LockoutCount { get; set; }
    public DateTime? MustChangePassword { get; set; }
    public DateTime? LastLogin { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    
    public virtual List<UserEmail> Emails { get; set; }
    
    public virtual List<Role> Roles { get; set; }
    
    public virtual List<Claim> Claims { get; set; }
}
