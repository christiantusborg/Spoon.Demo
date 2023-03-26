namespace Spoon.NuGet.SecureRemotePassword.Helpers;

public interface IEncryptionService
{
    string Encrypt(string str);
    string Decrypt(string str);
}