namespace Spoon.NuGet.SecureRemotePassword.Contracts;

public class UserClaimAddBulkCommandRequest
{
    public List<Guid> Claims { get; set; }
}