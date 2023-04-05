namespace Spoon.Demo.Domain.Entities;

using Spoon.NuGet.Core.Domain;
using Spoon.NuGet.Core.Domain.Primitives;

/// <summary>
/// Class Product.
/// Implements the <see cref="ISoftDeletableEntity" />
/// Implements the <see cref="Entity" />
/// Implements the <see cref="IAuditableEntity" />.
/// </summary>
/// <seealso cref="ISoftDeletableEntity" />
/// <seealso cref="Entity" />
/// <seealso cref="IAuditableEntity" />
public class Product : Entity
{
    /// <inheritdoc cref="Product" />
    public Guid ProductId { get; set; }

    /// <inheritdoc cref="Product" />
    public string? Name { get; set; }

    /// <inheritdoc cref="Product" />
    public double PurchasePrice { get; set; }

    /// <inheritdoc cref="Product" />
    public string Sku { get; set; } = null!;

    /// <inheritdoc cref="Product" />
    public string Description { get; set; } = String.Empty;

    /// <inheritdoc cref="Product" />
    public int GenderId { get; set; }

    /// <inheritdoc cref="Product" />
    public Guid SupplierId { get; set; }

    /// <inheritdoc />
    public DateTime CreatedAt { get; set; }
    
    /// <inheritdoc />
    public DateTime? ModifiedAt { get; set; }
    
    /// <inheritdoc />
    public DateTime? DeletedAt { get; set; }

    /// <inheritdoc cref="Product" />
    public virtual Supplier Supplier { get; set; }
    
    public virtual Gender Gender { get; set; }
    /// <inheritdoc cref="Product" />
    public virtual ICollection<Feature> Features { get; set; }    
}