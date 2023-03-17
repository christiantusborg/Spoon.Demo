namespace Spoon.Demo.Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;


    /// <summary>
    ///     Class ProductConfiguration.
    /// </summary>
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        /// <summary>
        ///     Configures the entity of type. />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => new
            {
                x.ProductId,
            }).HasName("PRIMARY");

            builder.ToTable("Product");

            builder.Property(e => e.Name);



            builder.Property(e => e.Sku).HasMaxLength(45);

            builder.Property(e => e.CreatedAt).HasColumnType("datetime");

            builder.Property(e => e.ModifiedAt).HasColumnType("datetime");

            builder.Property(e => e.DeletedAt).HasColumnType("datetime");


            builder.HasIndex(e => e.SupplierId, "FK_Product_SupplierId_idx");

            builder.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_Product_SupplierId");
        }
    }
}