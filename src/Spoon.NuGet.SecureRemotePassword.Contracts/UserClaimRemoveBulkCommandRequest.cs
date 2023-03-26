namespace Spoon.NuGet.SecureRemotePassword.Contracts;

public class UserClaimRemoveBulkCommandRequest
{
    public List<Guid> Claims { get; set; } = new List<Guid>();
}