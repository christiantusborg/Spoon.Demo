namespace Spoon.NuGet.SecureRemotePassword.Helpers;

using System.Buffers.Text;
using System.Drawing;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Core.Domain;

public static class SigningHelper
{
    public static string GetSignature<TEntity>(TEntity obj)
    {
        var args = new List<string>();
        foreach (PropertyInfo prop in typeof(TEntity).GetProperties())
        {

            if (prop.GetCustomAttribute<SignedExcludedAttribute>() != null)
                continue;
            
            if (prop.Name == "SignedHash")
                continue;

            var nextValue = prop.GetValue(obj, null).ToString();
            args.Add(nextValue);

        }
        
        var signature = string.Join("-", args);
        
        // Create a new instance of the MD5CryptoServiceProvider object.
        var md5Hasher = MD5.Create();
        // Convert the input string to a byte array and compute the hash.
        var data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(signature));
        var base64 = Convert.ToBase64String(data);
        
        return base64;
    }

    public static bool VerifySignature(this SignedEntity entity)
        {
            return entity.SignedHash == GetSignature(entity);
        }    
    }


    public class SignedExcludedAttribute : Attribute
    {
        public SignedExcludedAttribute()
        {
        }
    }
    

    public abstract class SignedEntity : Entity
    {

        [SignedExcluded]
        public required string SignedHash { get; set; }
    }


