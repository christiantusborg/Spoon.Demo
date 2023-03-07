namespace Spoon.NuGet.SecureRemotePassword.Application.Me.Email.Create
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class MeEmailCreateCommandResult
    {
        /// <inheritdoc cref="MeEmailCreateCommandResult" />
        public Guid UserId { get; internal set; }
        /// <inheritdoc cref="MeEmailCreateCommandResult" />
        public string? Email { get; internal set; }        
    }
}