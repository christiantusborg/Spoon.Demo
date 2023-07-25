namespace Spoon.Demo.Domain.Entities;

using NuGet.Core.Domain;

public class Gender : Entity
{
    public Guid GenderId { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public DateTime DeletedAt { get; set; }
    
    public ICollection<Color> Colors { get; set; }
    public ICollection<Size> Sizes { get; set; }
    public ICollection<Product> Products { get; set; }
}