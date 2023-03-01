namespace Spoon.Demo.Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Class SizeToProductConfiguration.
    /// </summary>
    internal class SizeToProductConfiguration : IEntityTypeConfiguration<SizeToProduct>
    {
        /// <summary>
        ///     Configures the entity of type. />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<SizeToProduct> builder)
        {
            builder.HasKey(e => new
                {
                    e.ProductId,
                    e.SizeId,
                    e.GenderId,
                })
                .HasName("PRIMARY");

            builder.ToTable("SizeToProduct");

            builder.HasIndex(e => e.GenderId, "FK_SizeToProduct_GenderId_idx");

            builder.HasIndex(e => e.ProductId, "FK_SizeToProduct_ProductId_idx");

            builder.HasIndex(e => e.SizeId, "FK_SizeToProduct_SizeId_idx");

            builder.HasOne(d => d.Gender).WithMany(p => p.SizeToProducts)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SizeToProduct_GenderId");

            builder.HasOne(d => d.Product).WithMany(p => p.SizeToProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SizeToProduct_ProductId");

            builder.HasOne(d => d.Size).WithMany(p => p.SizeToProducts)
                .HasForeignKey(d => d.SizeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SizeToProduct_SizeId");
        }
    }
}