namespace Spoon.NuGet.SecureRemotePassword.Persistence.Configuration;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SecureRemotePasswordByRecoveryCodeConfiguration : IEntityTypeConfiguration<SecureRemotePasswordByRecoveryCode>
{
    public void Configure(EntityTypeBuilder<SecureRemotePasswordByRecoveryCode> builder)
    {
        // Set the primary key
        builder.HasKey(p => p.UserId);

        // Set other properties
        builder.Property(p => p.VerifierEncrypted)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(p => p.SaltEncrypted)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(p => p.CreatedAt)
            .IsRequired();

        builder.HasOne(x => x.User)
            .WithMany(x => x.SecureRemotePasswordsByRecoveryCodes)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);        
        
        // Set the table name
        builder.ToTable("SecureRemotePasswordByRecoveryCodes");
    }
}