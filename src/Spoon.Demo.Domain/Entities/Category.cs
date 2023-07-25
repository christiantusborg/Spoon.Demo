namespace Spoon.Demo.Domain.Entities;

using NuGet.Core.Domain;

public class Category : Entity
{
    /// <inheritdoc cref="Category" />
    public Guid CategoryId { get; set; }
    /// <inheritdoc cref="Category" />
    public string Name { get; set; }
    /// <inheritdoc cref="Category" />
    public string Description { get; set; }
    /// <inheritdoc cref="Category" />
    public int Discount { get; set; }

    /// <inheritdoc cref="Category" />
    public int ProfitMargin { get; set; }
    /// <inheritdoc cref="Category" />
    public DateTime CreatedAt { get; set; }
    /// <inheritdoc cref="Category" />
    public DateTime ModifiedAt { get; set; }
    /// <inheritdoc cref="Category" />
    public DateTime? DeletedAt { get; set; }
    
    public ICollection<Product> Products { get; set; }
}