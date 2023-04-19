namespace Spoon.NuGet.SecureRemotePassword.Services;

using Domain.Entities;
using global::SecureRemotePassword;


/// <summary>
///  Interface ISecureRemotePasswordService. This interface cannot be inherited.
/// </summary>
public interface ISecureRemotePasswordService
{
    /// <summary>
    /// Determines whether the specified user is administrator.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    bool IsAdministrator(User user);
    
    /// <summary>
    /// Determines whether the specified user is administrator.
    /// </summary>
    /// <param name="password"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    (string Verifier,string Salt) GenerateVerifierAndSalt(string password,Guid userId);

    /// <summary>
    ///  Verifies the session. with Secure Remote Password
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="verifier"></param>
    /// <param name="salt"></param>
    /// <param name="serverSecretEphemeral"></param>
    /// <param name="clientPublicEphemeral"></param>
    /// <param name="clientSessionProof"></param>
    /// <param name="proof"></param>
    /// <returns></returns>
    bool VerifySession(Guid userId, string verifier, string salt, string serverSecretEphemeral, string clientPublicEphemeral, string clientSessionProof, out string? proof);
    
    /// <summary>
    ///  Generates the challenge.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="verifier"></param>
    /// <returns></returns>
    SrpEphemeral? GenerateChallenge(Guid userId, string verifier);
}