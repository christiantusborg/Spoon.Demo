namespace Spoon.NuGet.SecureRemotePassword.Contracts;

public class AdministrationSetUserPasswordRequest
{
    /// <inheritdoc cref="AdministrationSetUserPasswordRequest" />
    public Guid UserId { get; init; }
    /// <inheritdoc cref="AdministrationSetUserPasswordRequest" />
    public required string Verifier { get; init; }
    /// <inheritdoc cref="AdministrationSetUserPasswordRequest" />
    public required string Salt { get; init; }
}