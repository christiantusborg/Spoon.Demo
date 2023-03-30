namespace Spoon.NuGet.SecureRemotePassword.Integrity;

using System.Reflection;
using System.Security.Cryptography;
using System.Text;

public class EntityIntegrityService<TEntity> : IEntityIntegrityService<TEntity> where TEntity : class
{
    private readonly Func<string, string> hashFunc;

    public EntityIntegrityService(Func<string, string> hashFunc = null)
    {
        this.hashFunc = hashFunc ?? GenerateHash;
    }

    public string GenerateHash(string value)
    {
        using (var sha256 = SHA256.Create())
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            var hashBytes = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }
    }

    public string ConcatenateValues(IEnumerable<PropertyInfo> properties, TEntity entity)
    {
        var stringConcatenator = new StringBuilder();
        foreach (var property in properties)
        {
            var value = property.GetValue(entity)?.ToString() ?? "";
            stringConcatenator.Append($"{{{value}}}");
        }
        return stringConcatenator.ToString();
    }

    public string CalculateHash(TEntity entity)
    {
        var entityType = typeof(TEntity);
        var properties = entityType.GetProperties()
            .Where(p => p.GetCustomAttribute<IncludeInHashAttribute>() != null)
            .OrderBy(p => p.Name);

        var currentHash = ConcatenateValues(properties, entity);
        return currentHash;
    }

    public bool IsIntegrityValid(TEntity entity, string storedHash)
    {
        var currentHash = CalculateHash(entity);
        var calculatedHash = hashFunc(currentHash);

        return calculatedHash == storedHash;
    }
}