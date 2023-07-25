namespace Spoon.Demo.Domain.Entities;

using NuGet.Core.Domain;

public class ProductImage : Entity
{
    public Guid ProductImageId { get; set; }
    public string ImageUrl { get; set; }
    public Guid ProductId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public DateTime DeletedAt { get; set; }
    public virtual Product Product { get; set; }
}