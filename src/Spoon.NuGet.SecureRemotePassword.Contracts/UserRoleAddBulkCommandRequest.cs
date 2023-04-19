namespace Spoon.NuGet.SecureRemotePassword.Contracts;

public class UserRoleAddBulkCommandRequest
{
    public List<Guid> Roles { get; set; }
}