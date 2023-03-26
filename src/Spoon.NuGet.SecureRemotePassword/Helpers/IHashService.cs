namespace Spoon.NuGet.SecureRemotePassword.Helpers;

public interface IHashService
{
    string Hash(string str);
}