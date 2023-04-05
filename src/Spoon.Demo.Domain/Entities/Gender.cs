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
    public virtual ICollection<Color> Colors { get; set; }

    /// <inheritdoc cref="Gender" />
    public virtual ICollection<Size> Sizes { get; set;}
    
    public virtual ICollection<Product> Products { get; set;}
}
