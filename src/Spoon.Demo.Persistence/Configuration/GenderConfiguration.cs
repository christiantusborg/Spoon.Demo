namespace Spoon.Demo.Persistence.Configuration;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/*
public class GenderConfiguration : IEntityTypeConfiguration<Gender>
{
    public void Configure(EntityTypeBuilder<Gender> builder)
    {
        builder.ToTable("Genders");

        builder.HasKey(g => g.GenderId);
        builder.Property(g => g.GenderId).ValueGeneratedOnAdd();

        builder.Property(g => g.Name).HasMaxLength(50).IsRequired();

        builder.HasMany(g => g.Colors)
            .WithMany(c => c.Genders)
            .UsingEntity(j => j.ToTable("GenderColor"));

        builder.HasMany(g => g.Sizes)
            .WithMany(s => s.Genders)
            .UsingEntity(j => j.ToTable("GenderSize"));

        builder.HasMany(g => g.Products)
            .WithOne(p => p.Gender)
            .HasForeignKey(p => p.GenderId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
*/