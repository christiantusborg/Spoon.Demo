namespace Spoon.NuGet.SecureRemotePassword.Services.Implementation;

using System.Security;
using Domain.Entities;
using global::SecureRemotePassword;

public class SecureRemotePasswordService : ISecureRemotePasswordService
{
    public bool IsAdministrator(User user)
    {
        throw new NotImplementedException();
    }

    public (string Verifier, string Salt) GenerateVerifierAndSalt(string password, Guid userId)
    {
        var client = new SrpClient();
        var salt = client.GenerateSalt();
        var privateKey = client.DerivePrivateKey(salt, userId.ToString(), password);
        var verifier = client.DeriveVerifier(privateKey);

        return (verifier, salt);
    }

    public bool VerifySession(Guid userId, string verifier, string salt, string serverSecretEphemeral, string clientPublicEphemeral, string clientSessionProof, out string? proof)
    {
        try
        {
            var server = new SrpServer();
            var serverSession = server.DeriveSession(serverSecretEphemeral, clientPublicEphemeral, salt, userId.ToString(), verifier, clientSessionProof);
            proof = serverSession.Proof;
            return true;
        }
        catch (SecurityException exception)
        {
            //Security exception, so we should not throw it
        }
        catch (Exception exception)
        {
            //Not a security exception, so we should throw it
        }

        
        proof = null;
        return false;
    }

    public SrpEphemeral? GenerateChallenge(Guid userId, string verifier)
    {
        var server = new SrpServer();
        var serverEphemeral = server.GenerateEphemeral(verifier);
        return serverEphemeral;

    }
}