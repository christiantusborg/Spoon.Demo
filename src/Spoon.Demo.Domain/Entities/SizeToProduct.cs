namespace Spoon.Demo.Domain.Entities;

/// <summary>
/// 
/// </summary>
public partial class SizeToProduct
{
    /// <inheritdoc cref="SizeToProduct" />
    public int SizeId { get; set; }

    /// <inheritdoc cref="SizeToProduct" />
    public int ProductId { get; set; }

    /// <inheritdoc cref="SizeToProduct" />
    public int GenderId { get; set; }

    /// <inheritdoc cref="SizeToProduct" />
    public virtual Gender Gender { get; set; } = null!;

    /// <inheritdoc cref="SizeToProduct" />
    public virtual Product Product { get; set; } = null!;

    /// <inheritdoc cref="SizeToProduct" />
    public virtual Size Size { get; set; } = null!;
}
