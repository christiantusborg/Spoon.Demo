namespace Spoon.Demo.Domain.Entities;

using NuGet.Core.Domain;

public class OrderItem : Entity
{
    public Guid OrderProductId { get; set; }
    public Guid OrderId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Amount { get; set; }
    public int Discount { get; set; }
    public Guid OriginProductId { get; set; }
    public string OriginProductSerialized { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public DateTime DeletedAt { get; set; }
    public Order Order { get; set; }
}