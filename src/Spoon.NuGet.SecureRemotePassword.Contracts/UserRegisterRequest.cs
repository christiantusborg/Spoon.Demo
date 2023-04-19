namespace Spoon.NuGet.SecureRemotePassword.Contracts;

public class UserRegisterRequest
{
    public string Email { get; set; }
    public string Verifier { get; set; }
    public string Salt { get; set; }
    public string UsernameHash { get; set; }
}