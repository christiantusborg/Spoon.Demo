namespace Spoon.Demo.Domain.Entities;

using NuGet.Core.Domain;

public class Contact  : Entity
{
    public Guid ContactId { get; set; }
    public Guid CustomerId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Mobil { get; set; }
    public DateTime NewsLetterSignupDate { get; set; }
}