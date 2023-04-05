namespace Spoon.Demo.Persistence.Configuration;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class FeatureConfiguration : IEntityTypeConfiguration<Feature>
{
    public void Configure(EntityTypeBuilder<Feature> builder)
    {
        builder.ToTable("Features");

        builder.HasKey(f => f.FeatureId);
        builder.Property(f => f.FeatureId).ValueGeneratedOnAdd();

        builder.Property(f => f.Name).HasMaxLength(50).IsRequired();
        builder.Property(f => f.Value).HasMaxLength(50).IsRequired();

        builder.HasOne(f => f.FeatureType)
            .WithMany(ft => ft.Features)
            .HasForeignKey(f => f.FeatureTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(f => f.Products)
            .WithMany(p => p.Features)
            .UsingEntity(j => j.ToTable("ProductFeature"));
    }
}