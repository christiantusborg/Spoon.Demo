namespace Spoon.NuGet.SecureRemotePassword.Contracts;

public class UserForgotPasswordSetByEmailRequest
{
    public string Email { get; set; }
    public string Proof { get; set; }
    public string Salt { get; set; }
    public string Verifier { get; set; }
}