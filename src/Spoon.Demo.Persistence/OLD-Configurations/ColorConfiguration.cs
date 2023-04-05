/*
namespace Spoon.Demo.Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;


    /// <summary>
    ///     Class ColorConfiguration.
    /// </summary>
    internal class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        /// <summary>
        ///     Configures the entity of type. />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasKey(e => e.ColorId).HasName("PRIMARY");

            builder.ToTable("Color");

            builder.Property(e => e.Name);

            builder.Property(e => e.Hex);
        }
    }
}
*/