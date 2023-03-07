namespace Spoon.NuGet.SecureRemotePassword.Contracts;

public class UserForgotPasswordRecoverByEmailSetRequest
{
    public string Email { get; set; }
    public string Proof { get; set; }
}