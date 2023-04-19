namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Roles.Get
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class RoleGetCommandResult
    {
        /// <inheritdoc cref="RoleGetCommandResult" />
        public Guid RoleId { get; set; }
        /// <inheritdoc cref="RoleGetCommandResult" />
        public required string Name { get; set; }
        /// <inheritdoc cref="RoleGetCommandResult" />
        public DateTime CreatedAt { get; set; }
        /// <inheritdoc cref="RoleGetCommandResult" />
        public DateTime UpdatedAt { get; set; }
        /// <inheritdoc cref="RoleGetCommandResult" />
        public DateTime? DeletedAt { get; set; }
    }
}