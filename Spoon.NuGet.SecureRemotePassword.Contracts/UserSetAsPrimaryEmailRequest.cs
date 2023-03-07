namespace Spoon.NuGet.SecureRemotePassword.Contracts;

public class UserSetAsPrimaryEmailRequest
{
    public required Guid EmailId { get; init; }
}