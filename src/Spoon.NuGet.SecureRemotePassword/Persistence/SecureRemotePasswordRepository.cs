namespace Spoon.NuGet.SecureRemotePassword.Persistence;

using Domain.Entities.Repositories;
using Domain.Repositories;
using Repositories;


public class SecureRemotePasswordRepository : ISecureRemotePasswordRepository
{
    private readonly DemoContext _context;

    public SecureRemotePasswordRepository(DemoContext context)
    {
        _context = context;
        Claims = new ClaimRepository(context);
        UserEmails = new UserEmailRepository(context);
        UserEmailConfirms = new UserEmailConfirmRepository(context);
        Roles = new RoleRepository(context);
        SecureRemotePasswordByRecoveryCodes = new SecureRemotePasswordByRecoveryCodeRepository(context);
        SecureRemotePasswordByRecoveryEmails = new SecureRemotePasswordByRecoveryEmailRepository(context);
        SecureRemotePasswordLogins = new SecureRemotePasswordLoginRepository(context);
        Sessions = new SessionRepository(context);
        TwoFactorAuthenticationTOTPs = new TwoFactorAuthenticationTotpRepository(context);
        UserAllowedIpAccesses = new UserAllowedIpAccessRepository(context);
        UserLoginHistories = new UserLoginHistoryRepository(context);
        Users = new UserRepository(context);
    }

    public IClaimRepository Claims { get; }

    public IUserEmailRepository UserEmails { get; }

    public IUserEmailConfirmRepository UserEmailConfirms { get; }

    public IRoleRepository Roles { get; }

    public ISecureRemotePasswordByRecoveryCodeRepository SecureRemotePasswordByRecoveryCodes { get; }

    public ISecureRemotePasswordByRecoveryEmailRepository SecureRemotePasswordByRecoveryEmails { get; }

    public ISecureRemotePasswordLoginRepository SecureRemotePasswordLogins { get; }

    public ISessionRepository Sessions { get; }

    public ITwoFactorAuthenticationTotpRepository TwoFactorAuthenticationTOTPs { get; }

    public IUserAllowedIpAccessRepository UserAllowedIpAccesses { get; }

    public IUserLoginHistoryRepository UserLoginHistories { get; }

    public IUserRepository Users { get; }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}