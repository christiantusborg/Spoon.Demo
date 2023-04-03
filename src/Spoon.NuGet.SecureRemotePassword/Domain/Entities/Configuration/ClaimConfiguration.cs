namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


public class ClaimConfiguration  : IEntityTypeConfiguration<Claim>
{
    public void Configure(EntityTypeBuilder<Claim> builder)
    {
        // Set ClaimId as the primary key
        builder.HasKey(c => c.ClaimId);

        // Set other properties
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(255);
        
        builder.Property(c => c.CreatedAt)
            .IsRequired();

        builder.Property(c => c.UpdatedAt)
            .IsRequired();

        builder.Property(c => c.DeletedAt);
       //     .HasColumnType("datetime");

       builder.HasMany(x => x.Users)
           .WithMany(x => x.Claims)
           .UsingEntity<Dictionary<string, object>>(
               "UserClaims",
               x => x.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.Restrict),
               x => x.HasOne<Claim>().WithMany().HasForeignKey("ClaimId").OnDelete(DeleteBehavior.Cascade),
               x =>
               {
                   x.Property<DateTime>("CreatedAt").IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
                   x.HasKey("UserId", "ClaimId");
               });
        
       builder.HasMany(x => x.Roles)
           .WithMany(x => x.Claims)
           .UsingEntity<Dictionary<string, object>>(
               "RoleClaims",
               x => x.HasOne<Role>().WithMany().HasForeignKey("RoleId").OnDelete(DeleteBehavior.Restrict),
               x => x.HasOne<Claim>().WithMany().HasForeignKey("ClaimId").OnDelete(DeleteBehavior.Cascade),
               x =>
               {
                   x.Property<DateTime>("CreatedAt").IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
                   x.HasKey("RoleId", "ClaimId");
               });       
       
        // Set the table name
        builder.ToTable("Claims");
    }
}