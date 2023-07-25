namespace Spoon.Demo.Domain.Entities;

using NuGet.Core.Domain;

public class Color  : Entity
{
    public required Guid ColorId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime ModifiedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    
    public ICollection<Product> Products { get; set; } = null!;    
}