namespace Spoon.NuGet.SecureRemotePassword.Persistence.Configuration;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserLoginHistoryConfiguration : IEntityTypeConfiguration<UserLoginHistory>
{
    public void Configure(EntityTypeBuilder<UserLoginHistory> builder)
    {
        builder.ToTable("UserLoginHistories");

        builder.HasKey(x => x.UserLoginHistoryId);

        builder.Property(x => x.IpAddressHash).HasMaxLength(200).IsRequired();
        builder.Property(x => x.IpAddressEncrypted).HasMaxLength(200).IsRequired();
        builder.Property(x => x.UserAgentHash).HasMaxLength(500).IsRequired();
        builder.Property(x => x.IsSuccess).IsRequired();
        builder.Property(x => x.CreatedAt).IsRequired();
        
        builder.HasOne(x => x.User)
            .WithMany(x => x.UserLoginHistories)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}