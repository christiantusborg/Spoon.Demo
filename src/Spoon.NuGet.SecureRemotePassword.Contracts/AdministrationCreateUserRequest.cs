namespace Spoon.NuGet.SecureRemotePassword.Contracts;

public class AdministrationCreateUserRequest
{
   public string Email { get; set; }
   public string Salt { get; set; }
   public string Verifier { get; set; }
}