namespace Spoon.Demo.Domain.Entities;

/// <summary>
/// 
/// </summary>
public partial class Size
{
    /// <inheritdoc cref="Size" />
    public int SizeId { get; set; }

    /// <inheritdoc cref="Size" />
    public string Name { get; set; } = null!;

    /// <inheritdoc cref="Size" />
    public string Value { get; set; } = null!;

    /// <inheritdoc cref="Size" />
    public virtual ICollection<SizeToProduct> SizeToProducts { get; } = new List<SizeToProduct>();
}
