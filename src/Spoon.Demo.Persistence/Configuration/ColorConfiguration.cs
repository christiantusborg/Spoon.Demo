namespace Spoon.Demo.Persistence.Configuration;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ColorConfiguration : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> builder)
    {
        builder.ToTable("Colors");

        builder.HasKey(c => c.ColorId);
        builder.Property(c => c.ColorId).ValueGeneratedOnAdd();

        builder.Property(c => c.Name).HasMaxLength(50);
        builder.Property(c => c.Hex).HasMaxLength(7);

        builder.HasMany(c => c.Genders)
            .WithMany(g => g.Colors)
            .UsingEntity(j => j.ToTable("GenderColor"));
    }
}