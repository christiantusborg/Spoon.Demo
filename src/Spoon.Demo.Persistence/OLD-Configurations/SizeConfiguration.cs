/*
namespace Spoon.Demo.Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Class SizeConfiguration.
    /// </summary>
    internal class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        /// <summary>
        ///     Configures the entity of type. />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.HasKey(e => e.SizeId).HasName("PRIMARY");

            builder.ToTable("Size");

            builder.Property(e => e.Name);

            builder.Property(e => e.Value);
        }
    }
}
*/