namespace Spoon.NuGet.SecureRemotePassword.Application.Me.VerifyChallenge
{
    using Core.Application;
    using Domain.Entities;
    using Domain.Repositories;
    using EitherCore.Enums;
    using EitherCore.Helpers;
    using Helpers;
    using MediatR;
    using Services;
    using Spoon.NuGet.Core;
    using Spoon.NuGet.EitherCore;

    /// <summary>
    ///     Class ProductCreateQueryHandler. This class cannot be inherited.
    /// </summary>
    public sealed class MeVerifyChallengeGetCommandHandler : IRequestHandler<MeVerifyChallengeGetCommand, Either<MeVerifyChallengeGetCommandResult>>
    {
        private readonly ISecureRemotePasswordRepository _repository;
        private readonly ISecureRemotePasswordService _secureRemotePasswordService;
        private readonly IEncryptionService _encryptionService;
        private readonly IHashService _hashService;

        private readonly IMockbleGuidGenerator _mockbleGuidGenerator;

        /// <summary>
        /// </summary>
        /// <param name="writeRepository"></param>
        /// <param name="mockbleGuidGenerator"></param>
        public MeVerifyChallengeGetCommandHandler(ISecureRemotePasswordRepository repository, ISecureRemotePasswordService secureRemotePasswordService,IEncryptionService encryptionService,
            IHashService hashService)
        {
            this._repository = repository;
            this._secureRemotePasswordService = secureRemotePasswordService;
            this._encryptionService = encryptionService;
            this._hashService = hashService;
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
        public async Task<Either<MeVerifyChallengeGetCommandResult>> Handle(
            MeVerifyChallengeGetCommand request,
            CancellationToken cancellationToken)
        {
            
            var existingSecureRemotePasswordLogin = await this._repository.SecureRemotePasswordLogins.GetAsync(new DefaultGetSpecification<SecureRemotePasswordLogin>(request.UserId), cancellationToken);
            
            if (existingSecureRemotePasswordLogin == null)
                return EitherHelper<MeVerifyChallengeGetCommandResult>.EntityNotFound(typeof(SecureRemotePasswordLogin));

            
            var verifierDecrypted = this._encryptionService.Decrypt(existingSecureRemotePasswordLogin.VerifierEncrypted);
            
            var challenge = this._secureRemotePasswordService.GenerateChallenge(request.UserId, verifierDecrypted);
         
            var saltDecrypted = this._encryptionService.Decrypt(existingSecureRemotePasswordLogin.SaltEncrypted);
            
            var result = new MeVerifyChallengeGetCommandResult
            {
                Challenge = challenge,
                UserId = request.UserId,
                Salt = saltDecrypted,
            };
            return new Either<MeVerifyChallengeGetCommandResult>(result);
        }
    }
}