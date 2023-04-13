namespace Spoon.Demo.Persistence.Configuration;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
/*
public class SizeConfiguration : IEntityTypeConfiguration<Size>
{
    public void Configure(EntityTypeBuilder<Size> builder)
    {
        builder.HasKey(s => s.SizeId);
        builder.Property(s => s.Name).HasMaxLength(50).IsRequired();
        builder.Property(s => s.Value).HasMaxLength(50).IsRequired();

        builder.HasMany(s => s.Genders)
            .WithMany(g => g.Sizes)
            .UsingEntity(j => j.ToTable("GenderSize"));
    }
}
*/