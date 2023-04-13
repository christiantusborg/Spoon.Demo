namespace Spoon.NuGet.SecureRemotePassword.Services;

/// <summary>
/// Defines a service for generating random strings.
/// </summary>
public interface IRandomStringService
{
    /// <summary>
    /// Generates a random string of the specified length, containing the specified types of characters.
    /// </summary>
    /// <param name="length">The length of the random string to generate.</param>
    /// <param name="types">The types of characters to include in the random string. By default, includes letters, numbers, and special characters.</param>
    /// <returns>A random string of the specified length and character types.</returns>
    string CreateRandomString(int length, CharacterType types = CharacterType.Letter | CharacterType.Number | CharacterType.SpecialCharacter);
}
