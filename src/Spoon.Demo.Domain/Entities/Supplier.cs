namespace Spoon.Demo.Domain.Entities;

using NuGet.Core.Domain;

public class Supplier : Entity
{
    public Guid SupplierId { get; set; }
    public string Name { get; set; }
    public int Discount { get; set; }
    public int ProfitMargin { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public DateTime DeletedAt { get; set; }
}