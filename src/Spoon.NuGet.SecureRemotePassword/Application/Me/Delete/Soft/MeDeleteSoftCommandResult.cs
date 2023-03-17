namespace Spoon.NuGet.SecureRemotePassword.Application.Me.Delete.Soft
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class MeDeleteSoftCommandResult
    {
        /// <inheritdoc cref="MeDeleteSoftCommandResult" />
        public Guid UserId { get; internal set; }
        /// <inheritdoc cref="MeDeleteSoftCommandResult" />
        public string? Email { get; internal set; }        
    }
}