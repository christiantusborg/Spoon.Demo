// ReSharper disable ClassNeverInstantiated.Global

namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Administration.SetUserPassword;

using Core;
using Core.Application;
using Domain.Entities;
using Domain.Repositories;
using Helpers;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class AdministrationSetUserPasswordCommandHandler : IRequestHandler<AdministrationSetUserPasswordCommand, Either<AdministrationSetUserPasswordCommandResult>>
{
    private readonly IMockbleDateTime _mockbleDateTime;
    private readonly ISecureRemotePasswordRepository _repository;
    private readonly IEncryptionService _encryptionService;

    /// <summary>
    /// </summary>
    /// <param name="mockbleDateTime"></param>
    /// <param name="repository"></param>
    /// <param name="encryptionService"></param>
    public AdministrationSetUserPasswordCommandHandler(IMockbleDateTime mockbleDateTime, ISecureRemotePasswordRepository repository, IEncryptionService encryptionService)
    {
        this._mockbleDateTime = mockbleDateTime;
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
    public async Task<Either<AdministrationSetUserPasswordCommandResult>> Handle(
        AdministrationSetUserPasswordCommand request,
        CancellationToken cancellationToken)
    {
        var existingUser = await this._repository.Users.GetAsync(new DefaultGetSpecification<User>(request.UserId), cancellationToken);
        if (existingUser == null)
            return EitherHelper<AdministrationSetUserPasswordCommandResult>.EntityNotFound(typeof(User));

        var existingUserSecureRemotePasswordLogins = await this._repository.SecureRemotePasswordLogins.GetAsync(new DefaultGetSpecification<SecureRemotePasswordLogin>(request.UserId), cancellationToken);
        if (existingUserSecureRemotePasswordLogins == null)
            return EitherHelper<AdministrationSetUserPasswordCommandResult>.EntityNotFound(typeof(SecureRemotePasswordLogin));

        var verifierEncrypted = this._encryptionService.Encrypt(request.Verifier);
        existingUserSecureRemotePasswordLogins.VerifierEncrypted = verifierEncrypted;

        var saltEncrypted = this._encryptionService.Encrypt(request.Salt);
        existingUserSecureRemotePasswordLogins.SaltEncrypted = saltEncrypted;

        existingUser.LockoutEnd = null;
        existingUser.LockoutCount = 0;

        existingUserSecureRemotePasswordLogins.UpdatedAt = this._mockbleDateTime.UtcNow;

        return new Either<AdministrationSetUserPasswordCommandResult>(new AdministrationSetUserPasswordCommandResult());
    }
}