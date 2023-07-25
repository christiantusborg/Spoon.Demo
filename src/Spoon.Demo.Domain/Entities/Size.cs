namespace Spoon.Demo.Domain.Entities;

using NuGet.Core.Domain;

public class Size : Entity
{
    public Guid SizeId { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public DateTime DeletedAt { get; set; }
    public virtual ICollection<Gender> Genders { get; set; }
}