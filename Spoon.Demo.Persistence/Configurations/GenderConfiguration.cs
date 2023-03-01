namespace Spoon.Demo.Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    ///     Class GenderConfiguration.
    /// </summary>
    internal class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        /// <summary>
        ///     Configures the entity of type. />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasKey(e => e.GenderId).HasName("PRIMARY");

            builder.ToTable("Gender");

            builder.Property(e => e.Name);
        }
    }
}