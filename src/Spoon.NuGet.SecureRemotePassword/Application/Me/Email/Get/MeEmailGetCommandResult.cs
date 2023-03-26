namespace Spoon.NuGet.SecureRemotePassword.Application.Me.Email.Get
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class MeEmailGetCommandResult
    {
        public Guid UserId { get; set; }
        public Guid EmailId { get; set; }
        public string EmailAddress { get; set; }
    
        public DateTime? EmailAddressVerifiedAt { get; set; }
        public int IsPrimary { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}