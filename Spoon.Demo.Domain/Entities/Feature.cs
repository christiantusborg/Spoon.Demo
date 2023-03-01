namespace Spoon.Demo.Domain.Entities;

/// <summary>
/// 
/// </summary>
public partial class Feature
{
    /// <inheritdoc cref="Feature" />
    public int FeatureId { get; set; }

    /// <inheritdoc cref="Feature" />
    public string Name { get; set; } = null!;

    /// <inheritdoc cref="Feature" />
    public string Value { get; set; } = null!;

    /// <inheritdoc cref="Feature" />
    public int? FeatureTypeId { get; set; }

    /// <inheritdoc cref="Feature" />
    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
