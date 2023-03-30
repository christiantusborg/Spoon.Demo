namespace Spoon.NuGet.SecureRemotePassword.Integrity;

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
/*
public class HashValueConverter<TEntity> : ValueConverter<TEntity, string>
    
{
    public HashValueConverter()
        : base(
            coreValue => ToString(coreValue),
            efValue => FromString(efValue))
    {
    }

    private static string ToString(TEntity type)
    {
        return type switch
        {
            UserType.Customer => "C",
            UserType.Employee => "E",
            _ => throw new System.NotImplementedException(),
        };
    }

    private static TEntity FromString(string type)
    {
        return type.ToUpper() switch
        {
            "C" => UserType.Customer,
            "E" => UserType.Employee,
            _ => throw new System.NotImplementedException(),
        };
    }
}
*/