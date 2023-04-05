namespace Spoon.NuGet.SecureRemotePassword.Persistence.Configuration;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TwoFactorAuthenticationTOTPConfiguration : IEntityTypeConfiguration<TwoFactorAuthenticationTotp>
{
    public void Configure(EntityTypeBuilder<TwoFactorAuthenticationTotp> builder)
    {
        builder.HasKey(e => e.UserId);

        builder.Property(e => e.SecretKeyEncrypted).IsRequired();

        builder.Property(e => e.CreatedAt).IsRequired();

        builder.Property(e => e.UpdatedAt).IsRequired();

        builder.HasOne(x => x.User)
            .WithMany(x => x.TwoFactorAuthenticationTOTPs)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);  
    }
}