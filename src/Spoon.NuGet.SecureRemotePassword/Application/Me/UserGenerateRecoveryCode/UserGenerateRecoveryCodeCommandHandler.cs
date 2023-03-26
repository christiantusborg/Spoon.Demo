namespace Spoon.NuGet.SecureRemotePassword.Application.Me.UserGenerateRecoveryCode
{
    using Administration.SetUserPassword;
    using Core.Application;
    using CrypticWizard.RandomWordGenerator;
    using Domain.Entities;
    using Domain.Repositories;
    using EitherCore.Helpers;
    using MediatR;
    using Services;
    using Spoon.NuGet.Core;
    using Spoon.NuGet.EitherCore;

    /// <summary>
    ///     Class ProductCreateQueryHandler. This class cannot be inherited.
    /// </summary>
    public sealed class UserGenerateRecoveryCodeCommandHandler : IRequestHandler<UserGenerateRecoveryCodeCommand, Either<UserGenerateRecoveryCodeCommandResult>>
    {
        private readonly ISecureRemotePasswordRepository _repository;
        private readonly IMockbleDateTime _mockbleDateTime;
        private readonly ISecureRemotePasswordService _secureRemotePasswordService;


        /// <summary>
        /// </summary>
        /// <param name="writeRepository"></param>
        /// <param name="mockbleGuidGenerator"></param>
        public UserGenerateRecoveryCodeCommandHandler(ISecureRemotePasswordRepository repository, IMockbleDateTime mockbleDateTime, ISecureRemotePasswordService secureRemotePasswordService)
        {
            this._repository = repository;
            this._mockbleDateTime = mockbleDateTime;
            this._secureRemotePasswordService = secureRemotePasswordService;
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
            var existingUser = await this._repository.Users.Get(new DefaultGetSpecification<User>(request.UserId));
            if (existingUser == null)
                return EitherHelper<UserGenerateRecoveryCodeCommandResult>.EntityNotFound(typeof(User));            
            
            var existingUserSecureRemotePasswordLogins = await this._repository.SecureRemotePasswordByRecoveryCodes.Get(new DefaultGetSpecification<SecureRemotePasswordByRecoveryCode>(request.UserId));
            
            WordGenerator myWordGenerator = new WordGenerator();
            List<string> advs = myWordGenerator.GetWords(WordGenerator.PartOfSpeech.adv, 7);
            
            var recoveryCode = string.Join("-", advs);

            var verifierAndSalt = this._secureRemotePasswordService.GenerateVerifierAndSalt(recoveryCode, request.UserId);
            
            if (existingUserSecureRemotePasswordLogins != null)
            {
                existingUserSecureRemotePasswordLogins = new SecureRemotePasswordByRecoveryCode
                {
                    Verifier = verifierAndSalt.Verifier,
                    Salt = verifierAndSalt.Salt,
                    CreatedAt = this._mockbleDateTime.UtcNow,
                };
            }
            
            if (existingUserSecureRemotePasswordLogins == null)
            {
                existingUserSecureRemotePasswordLogins = new SecureRemotePasswordByRecoveryCode
                {
                    UserId = request.UserId,
                    CreatedAt = this._mockbleDateTime.UtcNow,
                    Verifier = verifierAndSalt.Verifier,
                    Salt = verifierAndSalt.Salt,
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
}