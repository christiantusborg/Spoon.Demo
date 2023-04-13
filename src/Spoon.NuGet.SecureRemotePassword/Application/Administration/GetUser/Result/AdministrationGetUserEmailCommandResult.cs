namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.GetUser;

/// <summary>
///   Class ProductCreateQueryResult. This class cannot be inherited.
/// </summary>
public class AdministrationGetUserEmailCommandResult
{
    /// <inheritdoc cref="AdministrationGetUserCommandResult" />
    public Guid EmailId { get; set; }
    /// <inheritdoc cref="AdministrationGetUserCommandResult" />
    public string? Email { get; set; }
    /// <inheritdoc cref="AdministrationGetUserCommandResult" />
    public bool IsPrimary { get; set; }
}