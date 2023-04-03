namespace Spoon.NuGet.SecureRemotePassword.Domain.Repositories;

using Entities;
using Entities.Repositories;

public interface ISecureRemotePasswordRepository
{
    public IClaimRepository Claims { get; }
    public IUserEmailRepository UserEmails { get; }
    public IUserEmailConfirmRepository UserEmailConfirms { get; }
    public IRoleClaimRepository RoleClaims { get; }
    public IRoleRepository Roles { get; }
    public ISecureRemotePasswordByRecoveryCodeRepository SecureRemotePasswordByRecoveryCodes { get; }
    public ISecureRemotePasswordByRecoveryEmailRepository SecureRemotePasswordByRecoveryEmails { get; }
    public ISecureRemotePasswordLoginRepository SecureRemotePasswordLogins { get; }
    public ISessionRepository Sessions { get; }
    public ITwoFactorAuthenticationTOTPRepository TwoFactorAuthenticationTOTPs { get; }
    public IUserAllowedIpAccessRepository UserAllowedIpAccesses { get; }
    public IUserLoginHistoryRepository UserLoginHistories { get; }
    public IUserRepository Users { get; }


    Task SaveChangesAsync(CancellationToken cancellationToken);
}