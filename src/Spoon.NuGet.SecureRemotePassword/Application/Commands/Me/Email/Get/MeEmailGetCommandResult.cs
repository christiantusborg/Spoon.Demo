// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Me.Email.Get
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class MeEmailGetCommandResult
    {
        /// <inheritdoc cref="MeEmailGetCommandResult" />
        public Guid UserId { get; set; }
        /// <inheritdoc cref="MeEmailGetCommandResult" />
        public Guid EmailId { get; set; }
        /// <inheritdoc cref="MeEmailGetCommandResult" />
        public string? EmailAddress { get; set; }
        /// <inheritdoc cref="MeEmailGetCommandResult" />
        public DateTime? EmailAddressVerifiedAt { get; set; }
        /// <inheritdoc cref="MeEmailGetCommandResult" />
        public int IsPrimary { get; set; }
        /// <inheritdoc cref="MeEmailGetCommandResult" />
        public DateTime CreatedAt { get; set; }
        /// <inheritdoc cref="MeEmailGetCommandResult" />
        public DateTime UpdatedAt { get; set; }
        /// <inheritdoc cref="MeEmailGetCommandResult" />
        public DateTime? DeletedAt { get; set; }
        
    }
}