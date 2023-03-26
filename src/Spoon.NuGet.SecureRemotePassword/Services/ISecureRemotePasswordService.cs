namespace Spoon.NuGet.SecureRemotePassword.Services;

using Domain.Entities;
using global::SecureRemotePassword;

public interface ISecureRemotePasswordService
{
    bool IsAdministator(User user);
    
    (string Verifier,string Salt) GenerateVerifierAndSalt(string password,Guid userId);

    bool VerifySession(Guid userId, string verifier, string salt, string serverSecretEphemeral, string clientPublicEphemeral, string clientSessionProof, out string? proof);
    SrpEphemeral? GenerateChallenge(Guid userId, string verifier);
}