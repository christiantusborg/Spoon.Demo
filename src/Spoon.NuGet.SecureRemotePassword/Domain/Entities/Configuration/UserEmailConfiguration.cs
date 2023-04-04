namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserEmailConfiguration : IEntityTypeConfiguration<UserEmail>
{
    public void Configure(EntityTypeBuilder<UserEmail> builder)
    {
        builder.HasKey(ue => new { ue.UserId, ue.EmailId });

        builder.HasOne(ue => ue.User)
            .WithMany(u => u.UserEmails)
            .HasForeignKey(ue => ue.UserId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasMany(u => u.UserEmailConfirms)
            .WithOne(u => u.UserEmail)
            .HasForeignKey(u => u.EmailId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
