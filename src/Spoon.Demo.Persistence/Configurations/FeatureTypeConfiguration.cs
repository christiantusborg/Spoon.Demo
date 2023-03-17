namespace Spoon.Demo.Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;


    /// <summary>
    ///     Class FeatureTypeConfiguration.
    /// </summary>
    internal class FeatureTypeConfiguration : IEntityTypeConfiguration<FeatureType>
    {
        /// <summary>
        ///     Configures the entity of type. />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<FeatureType> builder)
        {
            builder.HasKey(e => e.FeatureTypeId).HasName("PRIMARY");

            builder.ToTable("FeatureType");

            builder.Property(e => e.FeatureTypeId).ValueGeneratedNever();
            builder.Property(e => e.Name).HasMaxLength(45);
        }
    }
}