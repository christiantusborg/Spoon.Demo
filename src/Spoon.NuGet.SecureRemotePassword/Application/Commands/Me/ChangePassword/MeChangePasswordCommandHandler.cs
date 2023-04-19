// ReSharper disable ClassNeverInstantiated.Global
namespace Spoon.NuGet.SecureRemotePassword.Application.Commands.Me.ChangePassword;

using Core;
using Core.Application;
using Domain.Entities;
using Domain.Repositories;
using Helpers;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class MeChangePasswordCommandHandler : IRequestHandler<MeChangePasswordCommand, Either<MeChangePasswordCommandResult>>
{
    private readonly IMockbleDateTime _mockbleDateTime;
    private readonly ISecureRemotePasswordRepository _repository;
    private readonly IEncryptionService _encryptionService;


    /// <summary>
    /// </summary>
    /// <param name="mockbleDateTime"></param>
    /// <param name="repository"></param>
    /// <param name="encryptionService"></param>
    public MeChangePasswordCommandHandler(IMockbleDateTime mockbleDateTime, ISecureRemotePasswordRepository repository, IEncryptionService encryptionService)
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
    public async Task<Either<MeChangePasswordCommandResult>> Handle(
        MeChangePasswordCommand request,
        CancellationToken cancellationToken)
    {
        var existingUser = await this._repository.Users.GetAsync(new DefaultGetSpecification<User>(request.UserId), cancellationToken);
        if (existingUser == null)
            return EitherHelper<MeChangePasswordCommandResult>.EntityNotFound(typeof(User));

        var existingUserSecureRemotePasswordLogins = await this._repository.SecureRemotePasswordLogins.GetAsync(new DefaultGetSpecification<SecureRemotePasswordLogin>(request.UserId), cancellationToken);
        if (existingUserSecureRemotePasswordLogins == null)
            return EitherHelper<MeChangePasswordCommandResult>.EntityNotFound(typeof(SecureRemotePasswordLogin));

        var verifierEncrypted = this._encryptionService.Encrypt(request.Verifier);
        existingUserSecureRemotePasswordLogins.VerifierEncrypted = verifierEncrypted;

        var saltEncrypted = this._encryptionService.Encrypt(request.Salt);
        existingUserSecureRemotePasswordLogins.SaltEncrypted = saltEncrypted;

        existingUserSecureRemotePasswordLogins.UpdatedAt = this._mockbleDateTime.UtcNow;

        return new Either<MeChangePasswordCommandResult>(new MeChangePasswordCommandResult());
    }
}