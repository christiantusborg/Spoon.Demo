namespace Spoon.NuGet.SecureRemotePassword.Contracts;

/// <summary>
/// Api request model, Forgot password reset recover by email.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class UserForgotPasswordRecoverByEmailInitRequest
{
    /// <inheritdoc cref="UserForgotPasswordRecoverByEmailInitRequest" />
    public required string Email  { get; init; }   
}