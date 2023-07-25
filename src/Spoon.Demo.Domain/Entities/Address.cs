namespace Spoon.Demo.Domain.Entities;

using NuGet.Core.Domain;
using NuGet.SecureRemotePassword.Domain.Entities;

public class Address : Entity
{
    public Guid CustomerId { get; set; }
    public Guid AddressId { get; set; }
    public string AddressOneEncrypted { get; set; }
    public string? AddressTwoEncrypted { get; set; }
    public string Zip { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public int AddressTypeId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    
    public virtual Customer Customer { get; set; }
}