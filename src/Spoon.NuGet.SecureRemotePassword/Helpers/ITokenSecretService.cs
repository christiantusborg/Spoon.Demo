namespace Spoon.NuGet.SecureRemotePassword.Helpers;

/// <summary>
///   Interface ITokenSecretService. This interface cannot be inherited.
/// </summary>
public interface ITokenSecretService
{
    /// <summary>
    ///  Gets the token secret.
    /// </summary>
    /// <returns></returns>
    byte[] GetTokenSecret();
}