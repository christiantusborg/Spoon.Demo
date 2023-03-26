namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.GetUser
{
    using Domain.Entities;
    using Domain.Repositories;
    using EitherCore.Helpers;
    using Helpers;
    using MediatR;
    using Spoon.NuGet.Core;
    using Spoon.NuGet.EitherCore;

    /// <summary>
    ///     Class ProductCreateQueryHandler. This class cannot be inherited.
    /// </summary>
    public sealed class AdministrationGetUserCommandHandler : IRequestHandler<AdministrationGetUserCommand, Either<AdministrationGetUserCommandResult>>
    {
        private readonly ISecureRemotePasswordRepository _repository;
        private readonly IEncryptionService _encryptionService;

        /// <summary>
        /// </summary>
        /// <param name="writeRepository"></param>
        /// <param name="mockbleGuidGenerator"></param>
        public AdministrationGetUserCommandHandler(ISecureRemotePasswordRepository repository,IEncryptionService encryptionService)
        {
            this._repository = repository;
            this._encryptionService = encryptionService;
        }

        /// <summary>
        ///     Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">
        ///     The cancellation token that can be used by other objects or threads to receive notice
        ///     of cancellation.
        /// </param>
        /// <returns>Task&lt;Either&lt;ProductCreateQueryResult&gt;&gt;.</returns>
        public async Task<Either<AdministrationGetUserCommandResult>> Handle(
            AdministrationGetUserCommand request,
            CancellationToken cancellationToken)
        {
            var existingUser = await this._repository.Users.Get(new GetUserSpecification(request.UserId));
            
            if(existingUser == null)
                return EitherHelper<AdministrationGetUserCommandResult>.EntityNotFound(typeof(User));

            var primaryEmailDecrypted = GetPrimaryEmailDecrypted(existingUser);
            var getEmailsDecrypted = GetEmailsDecrypted(existingUser);
            var getUserRoles = this.GetUserRoles(existingUser);
            var getUserClaims = GetUserClaims(existingUser);
            var hashBuildInAdministator = this.HashBuildInAdministrator(existingUser);
            
            var result = new AdministrationGetUserCommandResult
            {
                UserId = existingUser.UserId,
                LastLogin = existingUser.LastLogin,
                LockoutCount = existingUser.LockoutCount,
                LockoutEnd = existingUser.LockoutEnd,
                DisabledAt = existingUser.DisabledAt,
                MustChangePassword = existingUser.MustChangePassword != null,
                CreatedAt = existingUser.CreatedAt,
                UpdatedAt = existingUser.UpdatedAt,
                DeletedAt = existingUser.DeletedAt,
                Email = primaryEmailDecrypted,
                Emails = getEmailsDecrypted,
                Roles = getUserRoles,
                Claims = getUserClaims,
                IsBuildInAdministrator = hashBuildInAdministator,
            };
            
            return new Either<AdministrationGetUserCommandResult>(result);
        }

        private bool HashBuildInAdministrator(User user)
        {
            throw new NotImplementedException();
        }

        private List<AdministrationGetUserClaimsCommandResult> GetUserClaims(User user)
        {
            var result = user.Claims.Select(userClaim => new AdministrationGetUserClaimsCommandResult
                {
                    ClaimId = userClaim.ClaimId,
                    ClaimName = userClaim.Name,
                })
                .ToList();
            
            return result;
        }

        private List<AdministrationGetUserRolesCommandResult> GetUserRoles(User user)
        {
            var result = user.Roles.Select(userRole=> new AdministrationGetUserRolesCommandResult
                {
                    RoleId = userRole.RoleId,
                    RoleName = userRole.Name,
                    Claims =  userRole.Claims.Select(userRoleClaim => new AdministrationGetUserClaimsCommandResult
                    {
                        ClaimId = userRoleClaim.ClaimId,
                        ClaimName = userRoleClaim.Name,
                    }).ToList(),
                })
                .ToList();
            
            return result;
        }

        private List<AdministrationGetUserEmailCommandResult> GetEmailsDecrypted(User user)
        {
            var result = user.Emails.Select(userEmail => new AdministrationGetUserEmailCommandResult
                {
                    EmailId = userEmail.EmailId,
                    Email = this._encryptionService.Decrypt(userEmail.EmailAddressEncrypted),
                    IsPrimary = userEmail.IsPrimary == 1,
                })
                .ToList();
            
            return result;
        }

        private string GetPrimaryEmailDecrypted(User user)
        {
            var result = user.Emails.Where(x => x.IsPrimary == 1).Select(userEmail => this._encryptionService.Decrypt(userEmail.EmailAddressEncrypted)).First();
            
            return result;
        }
    }
}