namespace Spoon.NuGet.SecureRemotePassword.Persistence;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class DemoContext : DbContext
{
    public DbSet<Claim> Claims { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<SecureRemotePasswordByRecoveryCode> SecureRemotePasswordByRecoveryCodes { get; set; }
    public DbSet<SecureRemotePasswordByRecoveryEmail> SecureRemotePasswordByRecoveryEmails { get; set; }
    public DbSet<SecureRemotePasswordLogin> SecureRemotePasswordLogins { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<TwoFactorAuthenticationTotp> TwoFactorAuthenticationTotps { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserAllowedIpAccess> UserAllowedIpAccesses { get; set; }
    public DbSet<UserEmail> UserEmails { get; set; }
    public DbSet<UserEmailConfirm> UserEmailConfirms { get; set; }
    public DbSet<UserLoginHistory> UserLoginHistories { get; set; }

    public DemoContext(DbContextOptions<DemoContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IAssemblyMarkerSecureRemotePassword).Assembly);

    }
}