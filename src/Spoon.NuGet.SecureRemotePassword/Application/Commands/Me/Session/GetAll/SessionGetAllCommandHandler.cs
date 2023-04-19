// ReSharper disable ClassNeverInstantiated.Global

namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Me.Session.GetAll;

using Administration.GetUser.Result;
using Core;
using Core.Application;
using Domain.Entities;
using Domain.Repositories;
using Helpers;

/// <summary>
///     Handles the AdministrationGetUserCommand by querying the repository for an existing user and returning the relevant
///     data.
/// </summary>
public sealed class SessionGetAllCommandHandler : IRequestHandler<SessionGetAllCommand, Either<BaseSearchCommandResult<SessionGetAllCommandResult>>>
{
    private readonly ISecureRemotePasswordRepository _repository;
    private readonly IEncryptionService _encryptionService;
    private readonly IMockbleDateTime _mockbleDateTime;

    /// <summary>
    ///     Initializes a new instance of the AdministrationGetUserCommandHandler class.
    /// </summary>
    /// <param name="repository">The repository to be used for retrieving user data.</param>
    /// <param name="encryptionService">The encryption service to be used for decrypting email addresses.</param>
    /// <param name="mockbleDateTime"></param>
    public SessionGetAllCommandHandler(ISecureRemotePasswordRepository repository, IEncryptionService encryptionService, IMockbleDateTime mockbleDateTime)
    {
        this._repository = repository;
        this._encryptionService = encryptionService;
        this._mockbleDateTime = mockbleDateTime;
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
    public async Task<Either<BaseSearchCommandResult<SessionGetAllCommandResult>>> Handle(
        SessionGetAllCommand request,
        CancellationToken cancellationToken)
    {
        var existingSessions = await this._repository.Sessions.SearchAsync(new GetByUserSpecification(request.UserId), cancellationToken);

        var expiredSessions = existingSessions.Where(x => x.SessionExpiresAt < this._mockbleDateTime.UtcNow);

        foreach (var expiredSession in expiredSessions)
        {
            this._repository.Sessions.Remove(expiredSession);
        }

        await this._repository.SaveChangesAsync(cancellationToken);


        if (existingSessions.Count == 0)
            return EitherHelper<BaseSearchCommandResult<SessionGetAllCommandResult>>.EntityNotFound(typeof(Session));

        var totalCount = await this._repository.Sessions.CountAsync(new GetByUserSpecification(request.UserId),cancellationToken);
        
        var result = new BaseSearchCommandResult<SessionGetAllCommandResult>
        {
            Total = totalCount,
            Items = existingSessions.Select(x => new SessionGetAllCommandResult
            {
                SessionId = x.ActionAt,
                ActionAt = x.ActionAt,
                IpAddressDecrypted = this._encryptionService.Decrypt(x.IpAddressEncrypted),
                UserAgentDecrypted = this._encryptionService.Decrypt(x.UserAgentEncrypted),
                SessionExpiresAt = x.SessionExpiresAt,
                RefreshTokenExpiresAt = x.SessionExpiresAt,
            }).ToList()
        };

        return new Either<BaseSearchCommandResult<SessionGetAllCommandResult>>(result);
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