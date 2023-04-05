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
    
    public virtual ICollection<Gender> Genders { get; set;}
}
