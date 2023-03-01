namespace Spoon.Demo.Domain.Entities;

/// <summary>
/// 
/// </summary>
public partial class ColorToProduct
{
    /// <inheritdoc cref="ColorToProduct" />
    public int ColorId { get; set; }

    /// <inheritdoc cref="ColorToProduct" />
    public int ProductId { get; set; }

    /// <inheritdoc cref="ColorToProduct" />
    public int GenderId { get; set; }

    /// <inheritdoc cref="ColorToProduct" />
    public virtual Color Color { get; set; } = null!;

    /// <inheritdoc cref="ColorToProduct" />
    public virtual Gender Gender { get; set; } = null!;

    /// <inheritdoc cref="ColorToProduct" />
    public virtual Product Product { get; set; } = null!;
}
