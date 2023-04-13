namespace Spoon.NuGet.SecureRemotePassword.Application.Me.UserGenerateRecoveryCode;

using Core;
using Core.Application;
using CrypticWizard.RandomWordGenerator;
using Domain.Entities;
using Domain.Repositories;
using EitherCore;
using EitherCore.Helpers;
using Helpers;
using MediatR;
using Services;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class UserGenerateRecoveryCodeCommandHandler : IRequestHandler<UserGenerateRecoveryCodeCommand, Either<UserGenerateRecoveryCodeCommandResult>>
{
    private readonly ISecureRemotePasswordRepository _repository;
    private readonly IMockbleDateTime _mockbleDateTime;
    private readonly ISecureRemotePasswordService _secureRemotePasswordService;
    private readonly IEncryptionService _encryptionService;


    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="mockbleDateTime"></param>
    /// <param name="secureRemotePasswordService"></param>
    /// <param name="encryptionService"></param>
    public UserGenerateRecoveryCodeCommandHandler(ISecureRemotePasswordRepository repository,
        IMockbleDateTime mockbleDateTime,
        ISecureRemotePasswordService secureRemotePasswordService,
        IEncryptionService encryptionService)
    {
        this._repository = repository;
        this._mockbleDateTime = mockbleDateTime;
        this._secureRemotePasswordService = secureRemotePasswordService;
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
    public async Task<Either<UserGenerateRecoveryCodeCommandResult>> Handle(
        UserGenerateRecoveryCodeCommand request,
        CancellationToken cancellationToken)
    {
        var existingUser = await this._repository.Users.GetAsync(new DefaultGetSpecification<User>(request.UserId), cancellationToken);
        if (existingUser == null)
            return EitherHelper<UserGenerateRecoveryCodeCommandResult>.EntityNotFound(typeof(User));

        var existingUserSecureRemotePasswordLogins =
            await this._repository.SecureRemotePasswordByRecoveryCodes.GetAsync(new DefaultGetSpecification<SecureRemotePasswordByRecoveryCode>(request.UserId), cancellationToken);


        var myWordGenerator = new WordGenerator();
        List<string> advs = myWordGenerator.GetWords(WordGenerator.PartOfSpeech.adv, 7);

        var recoveryCode = string.Join("-", advs);

        var verifierAndSalt = this._secureRemotePasswordService.GenerateVerifierAndSalt(recoveryCode, request.UserId);

        var verifierEncrypted = this._encryptionService.Encrypt(verifierAndSalt.Verifier);
        var saltEncrypted = this._encryptionService.Encrypt(verifierAndSalt.Salt);

        if (existingUserSecureRemotePasswordLogins != null)
        {
            existingUserSecureRemotePasswordLogins = new SecureRemotePasswordByRecoveryCode
            {
                VerifierEncrypted = verifierEncrypted,
                SaltEncrypted = saltEncrypted,
                CreatedAt = this._mockbleDateTime.UtcNow,
            };
        }

        if (existingUserSecureRemotePasswordLogins == null)
        {
            existingUserSecureRemotePasswordLogins = new SecureRemotePasswordByRecoveryCode
            {
                UserId = request.UserId,
                CreatedAt = this._mockbleDateTime.UtcNow,
                VerifierEncrypted = verifierEncrypted,
                SaltEncrypted = saltEncrypted,
            };

            this._repository.SecureRemotePasswordByRecoveryCodes.Add(existingUserSecureRemotePasswordLogins);
        }

        await this._repository.SaveChangesAsync(cancellationToken);

        var result = new UserGenerateRecoveryCodeCommandResult
        {
            RecoveryCode = recoveryCode,
        };

        return new Either<UserGenerateRecoveryCodeCommandResult>(result);
    }
}