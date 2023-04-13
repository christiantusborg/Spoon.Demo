namespace Spoon.Demo.Domain.Entities;

using NuGet.Core.Domain;

public class Color  : Entity
{
    public Guid ColorId { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public DateTime DeletedAt { get; set; }
}