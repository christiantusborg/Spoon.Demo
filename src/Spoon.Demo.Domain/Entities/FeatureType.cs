namespace Spoon.Demo.Domain.Entities;

using NuGet.Core.Domain;

public class FeatureType : Entity
{
    public Guid FeatureTypeId { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public DateTime DeletedAt { get; set; }
    public ICollection<Feature> Features { get; set; }
}