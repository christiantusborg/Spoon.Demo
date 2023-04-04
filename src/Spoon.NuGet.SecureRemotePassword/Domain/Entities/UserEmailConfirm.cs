namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities;

using Core.Domain;

public class UserEmailConfirm : Entity
{
    public Guid EmailId { get; set; }
    public string ConfirmationToken { get; set; }
    public DateTime CreatedAt { get; set; }
    public UserEmail UserEmail { get; set; }
}