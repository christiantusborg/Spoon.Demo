namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.GetUser;

/// <summary>
///  Class ProductCreateQueryResult. This class cannot be inherited.
/// </summary>
public class AdministrationGetUserClaimsCommandResult 
{
    /// <inheritdoc cref="AdministrationGetUserClaimsCommandResult" />
    public Guid ClaimId { get; set; }
    /// <inheritdoc cref="AdministrationGetUserClaimsCommandResult" />
    public required string ClaimName { get; set; }
}