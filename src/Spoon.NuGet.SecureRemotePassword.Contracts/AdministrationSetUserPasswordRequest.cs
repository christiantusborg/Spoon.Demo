namespace Spoon.NuGet.SecureRemotePassword.Contracts;

public class AdministrationSetUserPasswordRequest
{
    /// <inheritdoc cref="AdministrationSetPasswordCommand" />
    public Guid UserId { get; init; }
    /// <inheritdoc cref="AdministrationSetPasswordCommand" />
    public required string Verifier { get; init; }
    /// <inheritdoc cref="AdministrationSetPasswordCommand" />
    public required string Salt { get; init; }
}