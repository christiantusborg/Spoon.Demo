namespace Spoon.NuGet.SecureRemotePassword.Helpers;

using System.Drawing;
using System.Reflection;
using Core.Domain;

public static class SigningHelper
{
    public static string GetSignature(string[] args)
    {
        return "Bla bla bla";
    }
}



public abstract class SignedEntity<TEntity> : Entity
{

    public string SignedHash => this.GetSigningHash();

    private string GetSigningHash()
    {
        var args = new List<string>();
        foreach (PropertyInfo prop in typeof(TEntity).GetProperties())
        {

            var nextValue = prop.GetValue(this,null).ToString();
            args.Add(nextValue);

        }
        return SigningHelper.GetSignature(args.ToArray());
    }
    
    public bool VerifySignature()
    {
        return this.SignedHash == this.GetSigningHash();
    }
    
}