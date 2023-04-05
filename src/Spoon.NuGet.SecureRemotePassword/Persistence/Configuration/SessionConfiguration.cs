namespace Spoon.NuGet.SecureRemotePassword.Persistence.Configuration;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SessionConfiguration : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        // Set UserId as the primary key
        builder.HasKey(s => s.UserId);

        // Set other properties
        builder.Property(s => s.SessionId)
            .IsRequired();
        builder.Property(s => s.RefreshTokenHash)
            .IsRequired();
        builder.Property(s => s.IpAddressHash)
            .IsRequired();
        builder.Property(s => s.UserAgentHash)
            .IsRequired();
        builder.Property(s => s.CreatedAt)
            .IsRequired();
        builder.Property(s => s.ActionAt)
            .IsRequired();
        

        builder.HasKey(x => x.UserId);
        builder.HasOne(x => x.User)
            .WithMany(x => x.Sessions)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasIndex(s => s.SessionId);
        builder.HasIndex(s => s.RefreshTokenHash);
        builder.HasIndex(s => s.IpAddressHash);
        
        // Set the table name
        builder.ToTable("Sessions");
    }
}