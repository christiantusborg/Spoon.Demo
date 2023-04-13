namespace Spoon.NuGet.SecureRemotePassword.Services;


/// <summary>
/// Specifies the types of characters that can be included in a random string.
/// </summary>
[Flags]
public enum CharacterType
{
    /// <summary>
    /// Includes lowercase letters (excluding "i", "l", "0", and "j").
    /// </summary>
    LowerCaseLetter = 1,

    /// <summary>
    /// Includes upper- letters (excluding "I", "L", "O", and "J").
    /// </summary>
    UpperCaseLetter = 1,
    
    /// <summary>
    /// Includes digits "2" through "9".
    /// </summary>
    Number = 2,

    /// <summary>
    /// Includes 10 common special characters: "!@#$%^&amp;*()-_=+[]{}\\|;:'&quot;,.&lt;&gt;/?"
    /// </summary>
    SpecialCharacter = 4
}