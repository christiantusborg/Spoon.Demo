namespace Spoon.NuGet.SecureRemotePassword.Contracts;

public class UserRoleRemoveBulkCommandRequest
{
    public List<Guid> Claims { get; set; }   
}