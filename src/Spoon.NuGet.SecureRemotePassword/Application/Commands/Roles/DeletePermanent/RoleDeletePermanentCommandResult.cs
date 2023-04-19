namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Roles.DeletePermanent
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class RoleDeletePermanentCommandResult
    {
        /// <inheritdoc cref="RoleDeletePermanentCommandResult" />
        public Guid UserId { get; internal set; }
        /// <inheritdoc cref="RoleDeletePermanentCommandResult" />
        public string? Email { get; internal set; }        
    }
}