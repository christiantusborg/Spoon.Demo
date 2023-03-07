namespace Spoon.NuGet.SecureRemotePassword.Contracts;

public class AdministrationRemoveUserEmailRequest
{
    public Guid UserId { get; set; }
    public Guid EmailId { get; set; }
}