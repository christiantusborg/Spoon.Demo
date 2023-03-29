﻿namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.SetUserPassword
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
    public sealed class AdministrationSetUserPasswordCommandHandler : IRequestHandler<AdministrationSetUserPasswordCommand, Either<AdministrationSetUserPasswordCommandResult>>
    {
        private readonly IMockbleDateTime _mockbleDateTime;
        private readonly ISecureRemotePasswordRepository _repository;

        /// <summary>
        /// </summary>
        /// <param name="writeRepository"></param>
        /// <param name="mockbleGuidGenerator"></param>
        public AdministrationSetUserPasswordCommandHandler(IMockbleDateTime mockbleDateTime, ISecureRemotePasswordRepository repository)
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
        public async Task<Either<AdministrationSetUserPasswordCommandResult>> Handle(
            AdministrationSetUserPasswordCommand request,
            CancellationToken cancellationToken)
        {
            var existingUser = await this._repository.Users.Get(new DefaultGetSpecification<User>(request.UserId));
            if (existingUser == null)
                return EitherHelper<AdministrationSetUserPasswordCommandResult>.EntityNotFound(typeof(User));            
            
            var existingUserSecureRemotePasswordLogins = await this._repository.SecureRemotePasswordLogins.Get(new DefaultGetSpecification<SecureRemotePasswordLogin>(request.UserId));
            if (existingUserSecureRemotePasswordLogins == null)
                return EitherHelper<AdministrationSetUserPasswordCommandResult>.EntityNotFound(typeof(SecureRemotePasswordLogin));
            
            existingUserSecureRemotePasswordLogins.Verifier = request.Verifier;
            existingUserSecureRemotePasswordLogins.Salt = request.Salt;
            
            existingUser.LockoutEnd = null;
            existingUser.LockoutCount = 0;
            
            existingUserSecureRemotePasswordLogins.UpdatedAt = this._mockbleDateTime.UtcNow;
            
            return new Either<AdministrationSetUserPasswordCommandResult>(new AdministrationSetUserPasswordCommandResult());
        }
    }
}