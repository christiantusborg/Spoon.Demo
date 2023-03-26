namespace Spoon.NuGet.SecureRemotePassword.Contracts;

public class UserRoleAddBulkCommandRequest
{
    public List<Guid> Claims { get; set; }
}