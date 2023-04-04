namespace Spoon.NuGet.SecureRemotePassword.Domain.Entities.Extensions;

public static class UserExtensions
{
    public static bool IsDisabled(this User user)
    {
        return user.DisabledAt != null;
    }
}