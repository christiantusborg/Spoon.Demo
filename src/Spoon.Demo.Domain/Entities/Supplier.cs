namespace Spoon.Demo.Domain.Entities;

/// <summary>
/// 
/// </summary>
public partial class Supplier
{
    /// <inheritdoc cref="Supplier" />
    public Guid SupplierId { get; set; }

    /// <inheritdoc cref="Supplier" />
    public string Name { get; set; } = null!;

    /// <inheritdoc cref="Supplier" />
    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
