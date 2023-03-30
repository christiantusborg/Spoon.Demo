namespace Spoon.NuGet.SecureRemotePassword.Integrity;

using System.Reflection;

public interface IEntityIntegrityService<TEntity> where TEntity : class
{
    string GenerateHash(string value);
    string ConcatenateValues(IEnumerable<PropertyInfo> properties, TEntity entity);
    string CalculateHash(TEntity entity);
    bool IsIntegrityValid(TEntity entity, string storedHash);
}