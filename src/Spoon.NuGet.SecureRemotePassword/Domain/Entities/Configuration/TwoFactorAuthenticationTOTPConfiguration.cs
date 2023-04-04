namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class TwoFactorAuthenticationTOTPConfiguration : IEntityTypeConfiguration<TwoFactorAuthenticationTOTP>
{
    public void Configure(EntityTypeBuilder<TwoFactorAuthenticationTOTP> builder)
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