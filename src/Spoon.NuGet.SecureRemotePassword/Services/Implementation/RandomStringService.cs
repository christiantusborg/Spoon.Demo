namespace Spoon.NuGet.SecureRemotePassword.Services.Implementation;

/// <summary>
/// A service for generating random strings.
/// </summary>
public class RandomStringService : IRandomStringService
{
    /// <summary>
    /// Generates a random string of the specified length, containing the specified types of characters.
    /// </summary>
    /// <param name="length">The length of the random string to generate.</param>
    /// <param name="types">The types of characters to include in the random string. By default, includes letters, numbers, and special characters.</param>
    /// <returns>A random string of the specified length and character types.</returns>
    public string CreateRandomString(int length, CharacterType types = CharacterType.UpperCaseLetter| CharacterType.LowerCaseLetter | CharacterType.Number | CharacterType.SpecialCharacter)
    {
        var random = new Random();
        var charPool = "";
        var password = "";

        if (types.HasFlag(CharacterType.UpperCaseLetter))
        {
            // ReSharper disable once StringLiteralTypo
            charPool += "ABCDEFGHJKMNPQRSTVWXYZ";
        }

        if (types.HasFlag(CharacterType.LowerCaseLetter))
        {
            // ReSharper disable once StringLiteralTypo
            charPool += "abcdefghkmnpqrstvwxyz";
        }
        
        
        if (types.HasFlag(CharacterType.Number))
        {
            charPool += "23456789";
        }

        if (types.HasFlag(CharacterType.SpecialCharacter))
        {
            charPool += "!@#$%^&*-_=+?";
        }

        for (int i = 0; i < length; i++)
        {
            int index = random.Next(charPool.Length);
            password += charPool[index];
        }

        return password;
    } 
}