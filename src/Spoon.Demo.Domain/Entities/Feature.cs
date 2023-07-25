namespace Spoon.Demo.Domain.Entities;

using NuGet.Core.Domain;

public class Feature : Entity
{
    public required Guid FeatureId { get; set; }
    public required string Name { get; set; }
    public required string Value { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime ModifiedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public required Guid ProductId { get; set; }
    public ICollection<Product> Products { get; set; }
    public required Guid FeatureTypeId { get; set; }
    public FeatureType FeatureType { get; set; }
    
}