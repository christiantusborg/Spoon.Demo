namespace Spoon.Demo.Domain.Entities;

using NuGet.Core.Domain;

public class Customer  : Entity
{
    public required Guid CustomerId { get; set; }
    public required string Name { get; set; }
    public required string VatNumber { get; set; }
    public required Guid CustomerTypeId { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime ModifiedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public ICollection<Order> Orders { get; set; }
    public CustomerType CustomerType { get; set; }
    
}