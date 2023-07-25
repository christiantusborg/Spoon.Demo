namespace Spoon.Demo.Domain.Entities;

using NuGet.Core.Domain;

public class Order : Entity
{
    public Guid OrderId { get; set; }
    public Guid OriginAddressId { get; set; }
    public string OriginAddressSerialized { get; set; }
    public Guid Currency { get; set; }
    public double CurrencyExchangeRate { get; set; }
    public Guid Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public DateTime DeletedAt { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
    public Customer Customer { get; set; }
    
}

