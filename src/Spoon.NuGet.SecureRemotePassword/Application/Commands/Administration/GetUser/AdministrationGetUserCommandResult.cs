// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Administration.GetUser
{
    using Result;

    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class AdministrationGetUserCommandResult
    {
        /// <inheritdoc cref="AdministrationGetUserCommandResult" />
        public Guid UserId { get; set; }
        /// <inheritdoc cref="AdministrationGetUserCommandResult" />
        public DateTime? DisabledAt { get; set; }
        /// <inheritdoc cref="AdministrationGetUserCommandResult" />
        public DateTime? LockoutEnd { get; set; }
        /// <inheritdoc cref="AdministrationGetUserCommandResult" />
        public int LockoutCount { get; set; }
        /// <inheritdoc cref="AdministrationGetUserCommandResult" />
        public bool MustChangePassword { get; set; }
        /// <inheritdoc cref="AdministrationGetUserCommandResult" />
        public DateTime? LastLogin { get; set; }
        /// <inheritdoc cref="AdministrationGetUserCommandResult" />
        public required DateTime CreatedAt { get; set; }
        /// <inheritdoc cref="AdministrationGetUserCommandResult" />
        public required DateTime UpdatedAt { get; set; }
        /// <inheritdoc cref="AdministrationGetUserCommandResult" />
        public DateTime? DeletedAt { get; set; }

        /// <inheritdoc cref="AdministrationGetUserCommandResult" />
        public AdministrationGetUserEmailCommandResult Email { get; set; } = new AdministrationGetUserEmailCommandResult();

        /// <inheritdoc cref="AdministrationGetUserCommandResult" />
        public List<AdministrationGetUserEmailCommandResult> Emails { get; set; } = new List<AdministrationGetUserEmailCommandResult>();

        /// <inheritdoc cref="AdministrationGetUserCommandResult" />
        public List<AdministrationGetUserRolesCommandResult> Roles { get; set; } = new List<AdministrationGetUserRolesCommandResult>();

        /// <inheritdoc cref="AdministrationGetUserCommandResult" />
        public List<AdministrationGetUserClaimsCommandResult> Claims { get; set; } = new List<AdministrationGetUserClaimsCommandResult>();
        /// <inheritdoc cref="AdministrationGetUserCommandResult" />
        public bool IsBuildInAdministrator { get; set; }
    }
}