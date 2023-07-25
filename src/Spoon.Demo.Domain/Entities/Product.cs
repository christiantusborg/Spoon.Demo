namespace Spoon.Demo.Domain.Entities;

using NuGet.Core.Domain;

public class Product : Entity
{
    public Guid ProductId { get; set; }
    public Guid? UpdatedProductId { get; set; }
    public string Name { get; set; }
    public double PurchasePrice { get; set; }
    public string Sku { get; set; }
    public string Description { get; set; }
    public Guid SupplierId { get; set; }
    public int Discount { get; set; }
    public int ProfitMargin { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public virtual Supplier Supplier { get; set; }
    public virtual ICollection<Feature> Features { get; set; }
    public virtual ICollection<Gender> Genders { get; set; }
    public virtual ICollection<Category> Categories { get; set; }
    public virtual ICollection<ProductImage> ProductImages { get; set; }
}