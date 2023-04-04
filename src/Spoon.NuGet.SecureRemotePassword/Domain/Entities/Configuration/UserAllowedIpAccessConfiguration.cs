namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserAllowedIpAccessConfiguration : IEntityTypeConfiguration<UserAllowedIpAccess>
{
    public void Configure(EntityTypeBuilder<UserAllowedIpAccess> builder)
    {
        builder.HasKey(uaia => uaia.UserId);

        builder.Property(uaia => uaia.IpAddressHash).IsRequired();
        builder.Property(uaia => uaia.IpAddressEncrypted).IsRequired();
        builder.Property(uaia => uaia.CreatedAt).IsRequired();

        builder.HasMany(uaia => uaia.Users)
            .WithMany(u => u.UserAllowedIpAccesss)
            .UsingEntity<Dictionary<Guid, Guid>>(
                "UserAllowedIpAccessUser",
                ua => ua.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.NoAction),
                u => u.HasOne<UserAllowedIpAccess>().WithMany().HasForeignKey("UserAllowedIpAccessId").OnDelete(DeleteBehavior.Cascade),
                ua =>
                {
                    ua.HasKey("UserId", "UserAllowedIpAccessId");
                    ua.HasIndex("UserAllowedIpAccessId");
                }
            );
    }
}