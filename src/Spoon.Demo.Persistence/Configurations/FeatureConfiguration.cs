namespace Spoon.Demo.Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;


    /// <summary>
    ///     Class FeatureConfiguration.
    /// </summary>
    internal class FeatureConfiguration : IEntityTypeConfiguration<Feature>
    {
        /// <summary>
        ///     Configures the entity of type. />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.HasKey(e => e.FeatureId).HasName("PRIMARY");

            builder.ToTable("Feature");

            builder.Property(e => e.Name);

            builder.Property(e => e.Value);

            builder.HasMany(d => d.Products).WithMany(p => p.Features)
                .UsingEntity<Dictionary<string, object>>(
                    "FeatureToProduct",
                    r => r.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FeatureToProduct_ProductId"),
                    l => l.HasOne<Feature>().WithMany()
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_FeatureToProduct_FeatureId"),
                    j =>
                    {
                        j.HasKey("FeatureId", "ProductId")
                            .HasName("PRIMARY");
                        j.ToTable("FeatureToProduct");
                        j.HasIndex(new[]
                        {
                            "ProductId",
                        }, "FK_FeatureToProduct_ProductId_idx");
                    });
        }
    }
}