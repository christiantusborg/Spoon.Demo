namespace Spoon.Demo.Domain.Entities;

using NuGet.Core.Domain;

public class Customer  : Entity
{
    public Guid CustomerId { get; set; }
    public string Name { get; set; }
    public string VatNumber { get; set; }
    public Guid CustomerTypeId { get; set; }
    public string CreatedAt { get; set; }
    public string ModifiedAt { get; set; }
    public string DeletedAt { get; set; }
}