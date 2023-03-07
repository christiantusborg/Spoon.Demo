namespace Spoon.NuGet.SecureRemotePassword.Contracts;

/// <summary>
/// Api request model, add email.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public class MeEmailCreateRequest
{
    /// <inheritdoc cref="MeChangePasswordRequest" />
    public required string Email  { get; init; }
   
}