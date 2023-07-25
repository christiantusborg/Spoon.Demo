namespace Spoon.Demo.Application;

using NuGet.SecureRemotePassword.Helpers;

/// <summary>
///   Provides methods to encrypt and decrypt strings.
/// </summary>
public class EncryptionService : IEncryptionService
{
    /// <summary>
    ///  Encrypts the specified string.
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public string Encrypt(string str)
    {
        return str;
    }

    /// <summary>
    ///  Decrypts the specified string.
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public string Decrypt(string str)
    {
        return str;
    }
}