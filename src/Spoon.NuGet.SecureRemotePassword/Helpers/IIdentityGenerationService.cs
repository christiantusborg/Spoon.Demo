namespace Spoon.NuGet.SecureRemotePassword.Helpers;

/// <summary>
///   Interface for generating a JWT token.
/// </summary>
public interface IIdentityGenerationService
{
    /// <summary>
    ///  Generates a JWT token.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="emailId"></param>
    /// <param name="iat"></param>
    /// <param name="expirationTime"></param>
    /// <param name="customClaims"></param>
    /// <param name="sessionId"></param>
    /// <param name="refreshToken"></param>
    /// <returns></returns>
    string GenerateToken(Guid userId, Guid emailId,Guid sessionId,  string refreshToken, long iat,DateTime expirationTime , Dictionary<string, object>? customClaims = null);
    /// <summary>
    ///  Generates a refresh token.
    /// </summary>
    /// <param name="requestUserId"></param>
    /// <param name="emailEncryptedEmailId"></param>
    /// <param name="unixTimestamp"></param>
    /// <returns></returns>
    string GenerateRefreshToken(Guid requestUserId, Guid emailEncryptedEmailId, long unixTimestamp);
}