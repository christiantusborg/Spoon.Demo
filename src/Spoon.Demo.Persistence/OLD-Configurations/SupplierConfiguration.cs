/*
namespace Spoon.Demo.Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;


    /// <summary>
    ///     Class SupplierConfiguration.
    /// </summary>
    internal class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        /// <summary>
        ///     Configures the entity of type. />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(e => e.SupplierId).HasName("PRIMARY");

            builder.ToTable("Supplier");

            builder.Property(e => e.Name);
        }
    }
}
*/