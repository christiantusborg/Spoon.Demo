namespace Spoon.NuGet.SecureRemotePassword.ValueConverter;

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Security.Cryptography;
using Services;
using Services.Implementation;

public class EncryptedValueConverter<T> : ValueConverter<T, T> where T : class
{
    private readonly IAesEncryptionService _encryptionService;

    public EncryptedValueConverter(IAesEncryptionService encryptionService) : base(
        v => Encrypt(v, encryptionService),
        v => Decrypt(v, encryptionService),
        new ConverterMappingHints()) 
    {
        _encryptionService = encryptionService;
    }

    private static T Encrypt(T value, IAesEncryptionService encryptionService)
    {
        if (value == null) return null;

        var properties = typeof(T).GetProperties().Where(p => p.PropertyType == typeof(string) && p.Name.EndsWith("Encrypted"));

        foreach (var property in properties)
        {
            var propertyValue = property.GetValue(value);
            if (propertyValue is string strValue)
            {
                var encryptedValue = encryptionService.Encrypt(strValue);
                property.SetValue(value, encryptedValue);
            }
        }

        return value;
    }

    private static T Decrypt(T value, IAesEncryptionService encryptionService)
    {
        if (value == null) return null;

        var properties = typeof(T).GetProperties().Where(p => p.PropertyType == typeof(string) && p.Name.EndsWith("Encrypted"));

        foreach (var property in properties)
        {
            var propertyValue = property.GetValue(value);
            if (propertyValue is string strValue)
            {
                var decryptedValue = encryptionService.Decrypt(strValue);
                property.SetValue(value, decryptedValue);
            }
        }

        return value;
    }
}
/*
public abstract class BaseDbContext : DbContext
{
    private readonly AesEncryptionService _encryptionService;

    protected BaseDbContext(DbContextOptions options, AesEncryptionService encryptionService)
        : base(options)
    {
        _encryptionService = encryptionService;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(string) && property.Name.EndsWith("Encrypted"))
                {
                    property.SetValueConverter(new EncryptedValueConverter<string>(_encryptionService));
                }
            }
        }
    }
}

public class MyDbContext : BaseDbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options, AesEncryptionService encryptionService)
        : base(options, encryptionService)
    {
    }

    // Add your entity DbSet properties here
    public DbSet<User> Users { get; set; }
    public DbSet<Claim> Claims { get; set; }
    //...
}


using Azure.Identity;
using Azure.Security.KeyVault.Keys;

// Replace these values with your Azure Key Vault URL and key name
string keyVaultUrl = "https://my-key-vault.vault.azure.net/";
string keyName = "my-encryption-key";

// Create an instance of the KeyClient class to access the key
var credential = new DefaultAzureCredential();
var keyClient = new KeyClient(new Uri(keyVaultUrl), credential);

// Retrieve the encryption key from the Key Vault
KeyVaultKey key = await keyClient.GetKeyAsync(keyName);

// Get the key's value (the encryption key) as a byte array
byte[] encryptionKey = key.Key.ToByteArray();



*/


