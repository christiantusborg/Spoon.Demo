namespace Spoon.Demo.Persistence.Configuration;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/*
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.ProductId);
        builder.Property(p => p.Name).HasMaxLength(255);
        builder.Property(p => p.Sku).HasMaxLength(50).IsRequired();
        builder.Property(p => p.Description).HasMaxLength(1000);
        builder.Property(p => p.PurchasePrice).HasColumnType("decimal(18,2)").IsRequired();

        builder.HasOne(p => p.Supplier)
            .WithMany(s => s.Products)
            .HasForeignKey(p => p.SupplierId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Gender)
            .WithMany(g => g.Products)
            .HasForeignKey(p => p.GenderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.Features)
            .WithMany(f => f.Products)
            .UsingEntity(j => j.ToTable("ProductFeature"));
    }
}
*/