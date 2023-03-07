namespace Spoon.NuGet.SecureRemotePassword.Contracts;

/// <summary>
///     Api request model, change own password.
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public sealed class MeChangePasswordRequest
{
    /// <inheritdoc cref="MeChangePasswordRequest" />
    public required string Verifier { get; set; }

    /// <inheritdoc cref="MeChangePasswordRequest" />
    public required string Salt { get; set; }
}