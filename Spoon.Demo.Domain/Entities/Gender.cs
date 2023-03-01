namespace Spoon.Demo.Domain.Entities;

/// <summary>
/// 
/// </summary>
public partial class Gender
{
    /// <inheritdoc cref="Gender" />
    public int GenderId { get; set; }

    /// <inheritdoc cref="Gender" />
    public string Name { get; set; } = null!;

    /// <inheritdoc cref="Gender" />
    public virtual ICollection<ColorToProduct> ColorToProducts { get; } = new List<ColorToProduct>();

    /// <inheritdoc cref="Gender" />
    public virtual ICollection<SizeToProduct> SizeToProducts { get; } = new List<SizeToProduct>();
}
