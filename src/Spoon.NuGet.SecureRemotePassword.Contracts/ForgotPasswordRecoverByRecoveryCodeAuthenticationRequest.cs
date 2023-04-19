namespace Spoon.NuGet.SecureRemotePassword.Contracts;

/// <summary>
///   Class UserForgotPasswordRecoverByRecoveryCodeRequest. This class cannot be inherited.
/// </summary>
public class UserForgotPasswordRecoverByRecoveryCodeRequest
{
    /// <inheritdoc cref="UserForgotPasswordRecoverByRecoveryCodeRequest" />
    public required string UsernameHashed { get; set; }
    /// <inheritdoc cref="UserForgotPasswordRecoverByRecoveryCodeRequest" />
    public required string Verifier { get; init; }
    /// <inheritdoc cref="UserForgotPasswordRecoverByRecoveryCodeRequest" />
    public required string Salt { get; init; }

    
}