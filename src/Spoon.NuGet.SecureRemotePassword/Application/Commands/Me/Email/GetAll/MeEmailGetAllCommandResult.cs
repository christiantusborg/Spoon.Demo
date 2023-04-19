namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Me.Email.GetAll;

/// <summary>
///     Class ProductCreateQueryResult. This class cannot be inherited.
/// </summary>
public sealed class MeEmailGetAllCommandResult
{
    /// <inheritdoc cref="MeEmailGetAllCommandResult" />
    public Guid EmailId { get; set; }

    /// <inheritdoc cref="MeEmailGetAllCommandResult" />
    public string? Email { get; set; }

    /// <inheritdoc cref="MeEmailGetAllCommandResult" />
    public bool IsPrimary { get; set; }
}