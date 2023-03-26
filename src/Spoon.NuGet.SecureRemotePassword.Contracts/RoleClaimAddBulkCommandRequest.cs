namespace Spoon.NuGet.SecureRemotePassword.Contracts;

public class RoleClaimAddBulkCommandRequest
{
    public List<Guid> Claims { get; set; } = new List<Guid>();
}