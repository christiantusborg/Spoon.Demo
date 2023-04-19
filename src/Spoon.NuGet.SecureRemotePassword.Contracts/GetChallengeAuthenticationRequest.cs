namespace Spoon.NuGet.SecureRemotePassword.Contracts;

public class UserGetLoginChallengeRequest
{
  public required string UsernameHashed { get; set; }
}