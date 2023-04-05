namespace Spoon.NuGet.SecureRemotePassword.Persistence.Configuration;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SecureRemotePasswordByRecoveryEmailConfiguration : IEntityTypeConfiguration<SecureRemotePasswordByRecoveryEmail>
{
    public void Configure(EntityTypeBuilder<SecureRemotePasswordByRecoveryEmail> builder)
    {
        // Set the primary key
        builder.HasKey(p => p.UserId);
            
        builder.Property(s => s.EmailAddressHash)
            .IsRequired()
            .HasMaxLength(255);
        
        builder.Property(s => s.RecoveryTokenHash)
            .IsRequired()
            .HasMaxLength(255);
            
        builder.Property(s => s.CreatedAt)
            .IsRequired();
            
        builder.HasKey(x => x.UserId);
        builder.HasOne(x => x.User)
            .WithMany(x => x.SecureRemotePasswordByRecoveryEmails)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);
            
        builder.ToTable("SecureRemotePasswordByRecoveryEmails");
    }
}