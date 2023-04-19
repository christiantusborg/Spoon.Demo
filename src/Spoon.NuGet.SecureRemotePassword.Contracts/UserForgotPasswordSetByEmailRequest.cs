namespace Spoon.NuGet.SecureRemotePassword.Contracts;

public class UserForgotPasswordSetByEmailRequest
{
    public string Salt { get; set; }
    public string Verifier { get; set; }
    public string UsernameHashed { get; set; }
}