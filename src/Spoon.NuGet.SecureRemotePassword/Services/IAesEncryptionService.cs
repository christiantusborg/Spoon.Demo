namespace Spoon.NuGet.SecureRemotePassword.Services;

public interface IAesEncryptionService
{
    string Encrypt(string plainText);
    string Decrypt(string cipherText);
}