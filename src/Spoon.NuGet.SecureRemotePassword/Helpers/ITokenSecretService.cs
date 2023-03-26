namespace Spoon.NuGet.SecureRemotePassword.Helpers;

public interface ITokenSecretService
{
    byte[] GetTokenSecret();
}