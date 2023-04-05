namespace Spoon.Demo.Domain.Entities;

/// <summary>
/// 
/// </summary>
public partial class FeatureType
{
    /// <inheritdoc cref="FeatureType" />
    public int FeatureTypeId { get; set; }

    /// <inheritdoc cref="FeatureType" />
    public string Name { get; set; }
    
    public virtual ICollection<Feature> Features { get; set; }
}
