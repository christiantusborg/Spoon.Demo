namespace Spoon.NuGet.SecureRemotePassword.Application.Roles.Get
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class RoleGetCommandResult
    {
        /// <inheritdoc cref="RoleGetCommandResult" />

        public Guid RoleId { get; set; }

        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}