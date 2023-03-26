namespace Spoon.NuGet.SecureRemotePassword.Application.Claim.GetAll
{
    using Domain.Entities;

    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class ClaimGetAllCommandUserCommandResult
    {
        public List<Claim> Claims { get; set; }
    }
}