namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Administration.GetUser.Result;

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