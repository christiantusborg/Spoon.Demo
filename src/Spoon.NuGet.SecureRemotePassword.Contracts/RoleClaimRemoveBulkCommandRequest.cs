namespace Spoon.NuGet.SecureRemotePassword.Contracts;

public class RoleClaimRemoveBulkCommandRequest
{
    public List<Guid> Claims { get; set; } = new List<Guid>();
}