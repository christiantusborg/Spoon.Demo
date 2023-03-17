namespace Spoon.NuGet.SecureRemotePassword.Contracts;

public class UserRemoveEmailRequest
{
    public required Guid EmailId { get; init; }
}