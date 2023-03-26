namespace Spoon.NuGet.SecureRemotePassword.Application.Me.Email.GetAll
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class MeEmailGetAllCommandResult
    {
        /// <inheritdoc cref="MeEmailGetAllCommandResult" />
        public Guid UserId { get; internal set; }

        public List<MeEmailGetAllOneEmailCommandResult> Emails { get; set; }
    }

    public sealed class MeEmailGetAllOneEmailCommandResult
    {
        public Guid EmailId { get; set; }
        public string Email { get; set; }
        public bool IsPrimary { get; set; }
    }
}