namespace Spoon.Demo.Domain.Entities;

using NuGet.Core.Domain;

public class Feature : Entity
{
    public Guid FeatureId { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
    public Guid FeatureTypeId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public DateTime DeletedAt { get; set; }
}