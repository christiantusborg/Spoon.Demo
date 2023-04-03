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
    
    public virtual IEnumerable<UserEmail> UserEmails { get; set; }
    
    public virtual IEnumerable<Role> Roles { get; set; }
    
    public virtual IEnumerable<Claim> Claims { get; set; }
    public virtual IEnumerable<SecureRemotePasswordByRecoveryCode> SecureRemotePasswordsByRecoveryCodes { get; set; }
    public virtual  IEnumerable<SecureRemotePasswordByRecoveryEmail> SecureRemotePasswordByRecoveryEmails { get; set; }
    public virtual  IEnumerable<SecureRemotePasswordLogin> SecureRemotePasswordLogins { get; set; }
    public virtual IEnumerable<Session>? Sessions { get; set; }
    
    public virtual IEnumerable<TwoFactorAuthenticationTOTP> TwoFactorAuthenticationTOTPs { get; set;}
    
    public virtual IEnumerable<UserAllowedIpAccess> UserAllowedIpAccesss { get; set;}
    public IEnumerable<UserLoginHistory> UserLoginHistories { get; set; }
}
