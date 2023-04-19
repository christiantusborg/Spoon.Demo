// ReSharper disable ClassNeverInstantiated.Global

namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Administration.GetUser;

using Domain.Entities;
using Domain.Repositories;
using Helpers;
using Result;

/// <summary>
///     Handles the AdministrationGetUserCommand by querying the repository for an existing user and returning the relevant
///     data.
/// </summary>
public sealed class AdministrationGetUserCommandHandler : IRequestHandler<AdministrationGetUserCommand, Either<AdministrationGetUserCommandResult>>
{
    private readonly ISecureRemotePasswordRepository _repository;
    private readonly IEncryptionService _encryptionService;

    /// <summary>
    ///     Initializes a new instance of the AdministrationGetUserCommandHandler class.
    /// </summary>
    /// <param name="repository">The repository to be used for retrieving user data.</param>
    /// <param name="encryptionService">The encryption service to be used for decrypting email addresses.</param>
    public AdministrationGetUserCommandHandler(ISecureRemotePasswordRepository repository, IEncryptionService encryptionService)
    {
        this._repository = repository;
        this._encryptionService = encryptionService;
    }

    /// <summary>
    ///     Handles the AdministrationGetUserCommand request by querying the repository for an existing user and returning the
    ///     relevant data.
    /// </summary>
    /// <param name="request">The AdministrationGetUserCommand request to be handled.</param>
    /// <param name="cancellationToken">
    ///     The cancellation token that can be used by other objects or threads to receive notice
    ///     of cancellation.
    /// </param>
    /// <returns>
    ///     An Either object containing either the AdministrationGetUserCommandResult on success or an error message on
    ///     failure.
    /// </returns>
    public async Task<Either<AdministrationGetUserCommandResult>> Handle(
        AdministrationGetUserCommand request,
        CancellationToken cancellationToken)
    {
        // Get the existing user by id
        var existingUser = await this._repository.Users.GetAsync(new GetUserSpecification(request.UserId), cancellationToken);

        if (existingUser == null)
            return EitherHelper<AdministrationGetUserCommandResult>.EntityNotFound(typeof(User));

        // Get decrypted email addresses
        var getEmailsDecrypted = this.GetEmailsDecrypted(existingUser);

        // Get user roles and claims
        var getUserRoles = GetUserRoles(existingUser);
        var getUserClaims = GetUserClaims(existingUser);

        // Check if the user is a build-in administrator
        var hashBuildInAdministrator = HashBuildInAdministrator(getUserRoles);

        // Build the result object
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
            Email = getEmailsDecrypted.First(x => x.IsPrimary),
            Emails = getEmailsDecrypted.Where(x => !x.IsPrimary).ToList(),
            Roles = getUserRoles,
            Claims = getUserClaims,
            IsBuildInAdministrator = hashBuildInAdministrator,
        };

        return new Either<AdministrationGetUserCommandResult>(result);
    }

    /// <summary>
    ///     Determines if a user has the BuildInAdministrator role.
    /// </summary>
    /// <param name="roles">The list of roles to be checked.</param>
    /// <returns>True if the user has the BuildInAdministrator role, false otherwise.</returns>
    private static bool HashBuildInAdministrator(List<AdministrationGetUserRolesCommandResult> roles)
    {
        var result = roles.Any(x => x.RoleName is "Administrator" or "BuildInAdministrator" or "root");
        return result;
    }

    /// <summary>
    ///     Returns a list of user claims for the specified <paramref name="user" />.
    /// </summary>
    /// <param name="user">The user to retrieve claims for.</param>
    /// <returns>
    ///     A list of <see cref="AdministrationGetUserClaimsCommandResult" /> objects representing the claims for the
    ///     user.
    /// </returns>
    private static List<AdministrationGetUserClaimsCommandResult> GetUserClaims(User user)
    {
        var result = user.Claims.Select(userClaim => new AdministrationGetUserClaimsCommandResult
            {
                ClaimId = userClaim.ClaimId,
                ClaimName = userClaim.Name,
            })
            .ToList();

        return result;
    }

    /// <summary>
    ///     Returns a list of user roles for the specified <paramref name="user" />.
    /// </summary>
    /// <param name="user">The user to retrieve roles for.</param>
    /// <returns>A list of <see cref="AdministrationGetUserRolesCommandResult" /> objects representing the roles for the user.</returns>
    private static List<AdministrationGetUserRolesCommandResult> GetUserRoles(User user)
    {
        var result = user.Roles.Select(userRole => new AdministrationGetUserRolesCommandResult
            {
                RoleId = userRole.RoleId,
                RoleName = userRole.Name,
                Claims = userRole.Claims.Select(userRoleClaim => new AdministrationGetUserClaimsCommandResult
                {
                    ClaimId = userRoleClaim.ClaimId,
                    ClaimName = userRoleClaim.Name,
                }).ToList(),
            })
            .ToList();

        return result;
    }

    /// <summary>
    ///     Returns a list of user emails for the specified <paramref name="user" /> with decrypted email addresses.
    /// </summary>
    /// <param name="user">The user to retrieve emails for.</param>
    /// <returns>A list of <see cref="AdministrationGetUserEmailCommandResult" /> objects representing the emails for the user.</returns>
    private List<AdministrationGetUserEmailCommandResult> GetEmailsDecrypted(User user)
    {
        var result = user.UserEmails.Select(userEmail => new AdministrationGetUserEmailCommandResult
            {
                EmailId = userEmail.EmailId,
                Email = this._encryptionService.Decrypt(userEmail.EmailAddressEncrypted),
                IsPrimary = userEmail.IsPrimary == 1,
            })
            .ToList();

        return result;
    }
}