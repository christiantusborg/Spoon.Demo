namespace Spoon.NuGet.SecureRemotePassword.Contracts;

public class AdministrationSetUserEmailAsPrimaryRequest
{
    public Guid UserId { get; set; }
    public Guid EmailId { get; set; }
}