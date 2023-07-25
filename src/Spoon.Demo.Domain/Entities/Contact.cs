namespace Spoon.Demo.Domain.Entities;

using NuGet.Core.Domain;

public class Contact  : Entity
{
    public Guid ContactId { get; set; }
    public Guid CustomerId { get; set; }
  
    public string NameEncrypted { get; set; }
    public string EmailEncrypted { get; set; }
    public string PhoneEncrypted { get; set; }
    public string MobilEncrypted { get; set; }
    public DateTime? NewsLetterSignupDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public ICollection<Address> Addresses { get; set; }
    public ICollection<Note> Notes { get; set; }
    
}