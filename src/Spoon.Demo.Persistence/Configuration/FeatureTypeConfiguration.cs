namespace Spoon.Demo.Persistence.Configuration;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class FeatureTypeConfiguration : IEntityTypeConfiguration<FeatureType>
{
    public void Configure(EntityTypeBuilder<FeatureType> builder)
    {
        builder.ToTable("FeatureTypes");

        builder.HasKey(ft => ft.FeatureTypeId);
        builder.Property(ft => ft.FeatureTypeId).ValueGeneratedOnAdd();

        builder.Property(ft => ft.Name).HasMaxLength(50).IsRequired();

        builder.HasMany(ft => ft.Features)
            .WithOne(f => f.FeatureType)
            .HasForeignKey(f => f.FeatureTypeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}