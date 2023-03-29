﻿namespace Spoon.NuGet.SecureRemotePassword.Application.Me.ChangePassword
{
    using Core.Application;
    using Domain.Entities;
    using Domain.Repositories;
    using EitherCore.Helpers;
    using MediatR;
    using Spoon.NuGet.Core;
    using Spoon.NuGet.EitherCore;

    /// <summary>
    ///     Class ProductCreateQueryHandler. This class cannot be inherited.
    /// </summary>
    public sealed class MeChangePasswordCommandHandler : IRequestHandler<MeChangePasswordCommand, Either<MeChangePasswordCommandResult>>
    {
        private readonly IMockbleDateTime _mockbleDateTime;
        private readonly ISecureRemotePasswordRepository _repository;


        /// <summary>
        /// </summary>
        /// <param name="writeRepository"></param>
        /// <param name="mockbleGuidGenerator"></param>
        public MeChangePasswordCommandHandler(IMockbleDateTime mockbleDateTime, ISecureRemotePasswordRepository repository)
        {
            this._mockbleDateTime = mockbleDateTime;
            this._repository = repository;
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
            var existingUser = await this._repository.Users.Get(new DefaultGetSpecification<User>(request.UserId));
            if (existingUser == null)
                return EitherHelper<MeChangePasswordCommandResult>.EntityNotFound(typeof(User));            
            
            var existingUserSecureRemotePasswordLogins = await this._repository.SecureRemotePasswordLogins.Get(new DefaultGetSpecification<SecureRemotePasswordLogin>(request.UserId));
            if (existingUserSecureRemotePasswordLogins == null)
                return EitherHelper<MeChangePasswordCommandResult>.EntityNotFound(typeof(SecureRemotePasswordLogin));
            
            existingUserSecureRemotePasswordLogins.Verifier = request.Verifier;
            existingUserSecureRemotePasswordLogins.Salt = request.Salt;
            
            existingUserSecureRemotePasswordLogins.UpdatedAt = this._mockbleDateTime.UtcNow;
            
            return new Either<MeChangePasswordCommandResult>(new MeChangePasswordCommandResult());
        }
    }
}