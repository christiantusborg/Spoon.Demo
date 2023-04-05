namespace Spoon.NuGet.SecureRemotePassword.Services.Implementation;

using System.Security.Cryptography;
using System.Text;

public class AesEncryptionService : IAesEncryptionService
{
    private readonly byte[] _key;
    private readonly byte[] _iv;

    public AesEncryptionService(string key, string iv)
    {
        this._key = Encoding.UTF8.GetBytes(key);
        this._iv = Encoding.UTF8.GetBytes(iv);
    }

    public string Encrypt(string plainText)
    {
        byte[] encrypted;
        using (var aesAlg = Aes.Create())
        {
            aesAlg.Key = this._key;
            aesAlg.IV = this._iv;

            var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (var msEncrypt = new MemoryStream())
            {
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }

                    encrypted = msEncrypt.ToArray();
                }
            }
        }

        return Convert.ToBase64String(encrypted);
    }

    public string Decrypt(string cipherText)
    {
        var cipherBytes = Convert.FromBase64String(cipherText);

        using (var aesAlg = Aes.Create())
        {
            aesAlg.Key = this._key;
            aesAlg.IV = this._iv;

            var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (var msDecrypt = new MemoryStream(cipherBytes))
            {
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (var srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }
    }
}