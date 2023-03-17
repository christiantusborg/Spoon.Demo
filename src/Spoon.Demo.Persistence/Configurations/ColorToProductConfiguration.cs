namespace Spoon.Demo.Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Class ColorToProductConfiguration.
    /// </summary>
    internal class ColorToProductConfiguration : IEntityTypeConfiguration<ColorToProduct>
    {
        /// <summary>
        ///     Configures the entity of type. />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<ColorToProduct> builder)
        {
            builder.HasKey(e => new
                {
                    e.ColorId,
                    e.ProductId,
                    e.GenderId,
                  })
                .HasName("PRIMARY");


            builder.ToTable("ColorToProduct");

            builder.HasIndex(e => e.ColorId, "FK_ColorToProduct_ColorId_idx");

            builder.HasIndex(e => e.GenderId, "FK_ColorToProduct_GenderId_idx");

            builder.HasIndex(e => e.ProductId, "FK_ColorToProduct_ProductId_idx");

            builder.HasOne(d => d.Color).WithMany(p => p.ColorToProducts)
                .HasForeignKey(d => d.ColorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ColorToProduct_ColorId");

            builder.HasOne(d => d.Gender).WithMany(p => p.ColorToProducts)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ColorToProduct_GenderId");

            builder.HasOne(d => d.Product).WithMany(p => p.ColorToProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ColorToProduct_ProductId");
        }
    }
}