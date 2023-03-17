namespace Spoon.NuGet.SecureRemotePassword.Contracts;

public class UserSubmitLoginChallengeRequest
{
    public Guid UserId { get; set; }
    public string ClientSessionProof { get; set; }
}