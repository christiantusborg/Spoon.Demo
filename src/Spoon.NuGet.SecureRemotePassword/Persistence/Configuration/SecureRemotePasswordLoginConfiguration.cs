namespace Spoon.NuGet.SecureRemotePassword.Persistence.Configuration;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SecureRemotePasswordLoginConfiguration : IEntityTypeConfiguration<SecureRemotePasswordLogin>
{
    public void Configure(EntityTypeBuilder<SecureRemotePasswordLogin> builder)
    {
        // Set UserId as the primary key
        builder.HasKey(l => l.UserId);

        // Set other properties
        builder.Property(l => l.VerifierEncrypted)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(l => l.SaltEncrypted)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(l => l.UpdatedAt)
            .IsRequired();

        builder.HasKey(x => x.UserId);
        builder.HasOne(x => x.User)
            .WithMany(x => x.SecureRemotePasswordLogins)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);        
        
        // Set the table name
        builder.ToTable("SecureRemotePasswordLogins");
    }
}
