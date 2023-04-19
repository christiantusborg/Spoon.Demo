namespace Spoon.NuGet.SecureRemotePassword.Persistence.Configuration;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Set UserId as the primary key
        builder.HasKey(u => u.UserId);

        // Set other properties
        builder.Property(u => u.DisabledAt);
        builder.Property(u => u.LockoutEnd);
        builder.Property(u => u.LockoutCount);
        builder.Property(u => u.MustChangePassword);
        builder.Property(u => u.LastLogin);

        builder.Property(u => u.CreatedAt)
            .IsRequired();

        builder.Property(u => u.UpdatedAt)
            .IsRequired();

        builder.Property(u => u.DeletedAt);

        builder.HasMany(x => x.Claims)
            .WithMany(x => x.Users)
            .UsingEntity<Dictionary<Guid, Guid>>(
                "UserClaims",
                x => x.HasOne<Claim>().WithMany().HasForeignKey("ClaimId").OnDelete(DeleteBehavior.Restrict),
                x => x.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.Cascade),
                x =>
                {
                    x.Property<DateTime>("CreatedAt").IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
                    x.HasKey("UserId", "ClaimId");
                });        
        
        builder.HasMany(x => x.Roles)
            .WithMany(x => x.Users)
            .UsingEntity<Dictionary<Guid, Guid>>(
                "UserRole",
                x => x.HasOne<Role>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.Cascade),
                x => x.HasOne<User>().WithMany().HasForeignKey("RoleId").OnDelete(DeleteBehavior.Restrict),
                x =>
                {
                    x.Property<DateTime>("CreatedAt").IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
                    x.HasKey("UserId", "RoleId");
                });        
        
        // Set up navigation properties
        builder.HasMany(u => u.UserEmails)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Add this line for SecureRemotePasswordByRecoveryCode
        builder.HasMany(u => u.SecureRemotePasswordsByRecoveryCodes)
            .WithOne(srp => srp.User)
            .HasForeignKey(srp => srp.UserId)
            .OnDelete(DeleteBehavior.Cascade);        
        
        // Add this line for SecureRemotePasswordByRecoveryEmail
        builder.HasMany(u => u.SecureRemotePasswordByRecoveryEmails)
            .WithOne(srp => srp.User)
            .HasForeignKey(s => s.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // Add this line for SecureRemotePasswordLogins
        builder.HasMany(u => u.SecureRemotePasswordLogins)
            .WithOne(srp => srp.User)
            .HasForeignKey(s => s.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        //Session
     
        builder.HasMany(x => x.Sessions)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(u => u.TwoFactorAuthenticationTotp)
            .WithOne(t => t.User)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(u => u.UserAllowedIpAccess)
            .WithMany(uaia => uaia.Users)
            .UsingEntity<Dictionary<string, object>>(
                "UserAllowedIpAccessUser",
                ua => ua.HasOne<UserAllowedIpAccess>().WithMany().HasForeignKey("UserAllowedIpAccessId").OnDelete(DeleteBehavior.Cascade),
                u => u.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.Restrict),
                ua =>
                {
                    ua.HasKey("UserAllowedIpAccessId", "UserId");
                    ua.HasIndex("UserId");
                }
            );  
        
        builder.HasMany(x => x.UserLoginHistories)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);        
        
        // Set up navigation properties
        builder.HasMany(u => u.Roles)
            .WithMany(r => r.Users);

        builder.HasMany(u => u.Claims)
            .WithMany(c => c.Users);

        // Set the table name
        builder.ToTable("Users");
    }
}