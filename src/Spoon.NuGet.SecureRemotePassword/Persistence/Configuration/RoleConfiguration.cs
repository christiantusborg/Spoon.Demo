namespace Spoon.NuGet.SecureRemotePassword.Persistence.Configuration;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        // Set RoleId as the primary key
        builder.HasKey(r => r.RoleId);

        // Set other properties
        builder.Property(r => r.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(r => r.CreatedAt)
            .IsRequired();

        builder.Property(r => r.UpdatedAt)
            .IsRequired();

        builder.Property(r => r.DeletedAt);

        // Set up navigation properties
        builder.HasMany(r => r.Claims)
            .WithMany(c => c.Roles);

        builder.HasMany(r => r.Users)
            .WithMany(u => u.Roles);

        builder.HasMany(x => x.Users)
            .WithMany(x => x.Roles)
            .UsingEntity<Dictionary<string, object>>(
                "UserClaims",
                x => x.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.NoAction),
                x => x.HasOne<Role>().WithMany().HasForeignKey("RoleId").OnDelete(DeleteBehavior.Cascade),
                x =>
                {
                    x.Property<DateTime>("CreatedAt").IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
                    x.HasKey("UserId", "RoleId");
                });
        
        builder.HasMany(x => x.Claims)
            .WithMany(x => x.Roles)
            .UsingEntity<Dictionary<string, object>>(
                "RoleClaims",
                x => x.HasOne<Claim>().WithMany().HasForeignKey("RoleId").OnDelete(DeleteBehavior.Cascade),
                x => x.HasOne<Role>().WithMany().HasForeignKey("ClaimId").OnDelete(DeleteBehavior.NoAction),
                x =>
                {
                    x.Property<DateTime>("CreatedAt").IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
                    x.HasKey("RoleId", "ClaimId");
                });        
        
        // Set the table name
        builder.ToTable("Roles");
    }
}