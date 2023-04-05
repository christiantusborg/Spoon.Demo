namespace Spoon.NuGet.SecureRemotePassword.Persistence.Configuration;

using Domain.Entities;
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