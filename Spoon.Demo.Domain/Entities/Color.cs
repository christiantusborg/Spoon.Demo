namespace Spoon.Demo.Domain.Entities;

/// <summary>
/// 
/// </summary>
public partial class Color
{
    /// <inheritdoc cref="Color" />
    public int ColorId { get; set; }

    /// <inheritdoc cref="Color" />
    public string? Name { get; set; }

    /// <inheritdoc cref="Color" />
    public string? Hex { get; set; }

    /// <inheritdoc cref="Color" />
    public virtual ICollection<ColorToProduct> ColorToProducts { get; } = new List<ColorToProduct>();
}
