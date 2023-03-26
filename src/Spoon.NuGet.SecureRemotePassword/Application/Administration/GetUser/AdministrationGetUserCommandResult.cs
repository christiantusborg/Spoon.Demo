namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.GetUser
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class AdministrationGetUserCommandResult
    {
        public Guid UserId { get; set; }
        public DateTime? DisabledAt { get; set; }
        public DateTime? LockoutEnd { get; set; }
        public int LockoutCount { get; set; }
        public bool MustChangePassword { get; set; }
        public DateTime? LastLogin { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string Email { get; set; }
        public List<AdministrationGetUserEmailCommandResult> Emails { get; set; }
        public List<AdministrationGetUserRolesCommandResult> Roles { get; set; }
        public List<AdministrationGetUserClaimsCommandResult> Claims { get; set; }
        public bool IsBuildInAdministrator { get; set; }
    }
    
    public class AdministrationGetUserEmailCommandResult
    {
        public Guid EmailId { get; set; }
        public string Email { get; set; }
        public bool IsPrimary { get; set; }
    }
    
    public class AdministrationGetUserRolesCommandResult 
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public List<AdministrationGetUserClaimsCommandResult> Claims { get; set; }
    }
    
    public class AdministrationGetUserClaimsCommandResult 
    {
        public Guid ClaimId { get; set; }
        public string ClaimName { get; set; }
    }
    
}