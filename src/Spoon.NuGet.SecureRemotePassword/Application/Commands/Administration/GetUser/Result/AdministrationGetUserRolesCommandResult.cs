namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Administration.GetUser.Result;

/// <summary>
///  Class ProductCreateQueryResult. This class cannot be inherited.
/// </summary>
public class AdministrationGetUserRolesCommandResult 
{
    /// <inheritdoc cref="AdministrationGetUserRolesCommandResult" />
    public Guid RoleId { get; set; }
    /// <inheritdoc cref="AdministrationGetUserRolesCommandResult" />
    public required string RoleName { get; set; }
    /// <inheritdoc cref="AdministrationGetUserRolesCommandResult" />
    public List<AdministrationGetUserClaimsCommandResult> Claims { get; set; } = new List<AdministrationGetUserClaimsCommandResult>();
}