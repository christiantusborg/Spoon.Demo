namespace Spoon.NuGet.SecureRemotePassword.Application.Administration.SetUserAllowedLogin
{
    using Core.Application;
    using DeleteUserPermanent;
    using Domain.Entities;
    using Domain.Repositories;
    using EitherCore.Helpers;
    using MediatR;
    using Spoon.NuGet.Core;
    using Spoon.NuGet.EitherCore;

    /// <summary>
    ///     Class ProductCreateQueryHandler. This class cannot be inherited.
    /// </summary>
    public sealed class AdministrationSetUserAllowedLoginCommandHandler : IRequestHandler<AdministrationSetUserAllowedLoginCommand, Either<AdministrationSetUserAllowedLoginCommandResult>>
    {

        private readonly ISecureRemotePasswordRepository _repository;
        private readonly IMockbleDateTime _mockbleDateTime;

        /// <summary>
        /// </summary>
        /// <param name="writeRepository"></param>
        /// <param name="mockbleGuidGenerator"></param>
        public AdministrationSetUserAllowedLoginCommandHandler(ISecureRemotePasswordRepository repository, IMockbleDateTime mockbleDateTime)
        {
            this._repository = repository;
            this._mockbleDateTime = mockbleDateTime;
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
        public async Task<Either<AdministrationSetUserAllowedLoginCommandResult>> Handle(
            AdministrationSetUserAllowedLoginCommand request,
            CancellationToken cancellationToken)
        {
            var existingUser = await this._repository.Users.GetAsync(new DefaultGetSpecification<User>(request.UserId), cancellationToken);
            if (existingUser == null)
                return EitherHelper<AdministrationSetUserAllowedLoginCommandResult>.EntityNotFound(typeof(User));
            
            
            existingUser.DisabledAt = request.Value ? null : this._mockbleDateTime.UtcNow;
            existingUser.UpdatedAt = this._mockbleDateTime.UtcNow;
            
            return new Either<AdministrationSetUserAllowedLoginCommandResult>(new AdministrationSetUserAllowedLoginCommandResult());
        }
    }
}