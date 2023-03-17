namespace Spoon.NuGet.SecureRemotePassword.Contracts;

public class UserForgotPasswordRecoverByRecoveryCodeRequest
{
    public string Email { get; set; }
    public string Salt { get; set; }
    public string Verifier { get; set; }
    public string RecoveryCode { get; set; }
}