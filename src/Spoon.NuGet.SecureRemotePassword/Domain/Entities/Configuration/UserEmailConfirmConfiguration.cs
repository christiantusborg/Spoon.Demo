namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserEmailConfirmConfiguration : IEntityTypeConfiguration<UserEmailConfirm>
{
    public void Configure(EntityTypeBuilder<UserEmailConfirm> builder)
    {
        builder.HasOne(u => u.UserEmail)
            .WithMany(u => u.UserEmailConfirms)
            .HasForeignKey(u => u.EmailId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}