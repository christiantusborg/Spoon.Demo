namespace Spoon.NuGet.SecureRemotePassword.Application.Roles.GetAll
{
    using Domain.Entities;

    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class RoleGetAllCommandResult
    {
        public List<RoleGetAllLRolesCommandResult> Roles { get; set; } = new List<RoleGetAllLRolesCommandResult>();
    }

    public sealed class RoleGetAllLRolesCommandResult
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}