namespace Spoon.NuGet.SecureRemotePassword.Application.Claim.GetAll
{
    using Administration.DeleteUserPermanent;
    using Core.Application;
    using Domain.Entities;
    using Domain.Repositories;
    using EitherCore.Enums;
    using EitherCore.Helpers;
    using MediatR;
    using SharedSpecification;
    using Spoon.NuGet.Core;
    using Spoon.NuGet.EitherCore;

    /// <summary>
    ///     Class ProductCreateQueryHandler. This class cannot be inherited.
    /// </summary>
    public sealed class ClaimGetAllCommandHandler : IRequestHandler<ClaimGetAllCommand, Either<ClaimGetAllCommandUserCommandResult>>
    {
        private readonly ISecureRemotePasswordRepository _repository;


        /// <summary>
        /// </summary>
        /// <param name="writeRepository"></param>
        /// <param name="mockbleGuidGenerator"></param>
        public ClaimGetAllCommandHandler(ISecureRemotePasswordRepository repository)
        {
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
        public async Task<Either<ClaimGetAllCommandUserCommandResult>> Handle(
            ClaimGetAllCommand request,
            CancellationToken cancellationToken)
        {
            var claims = await this._repository.Claims.GetAllAsync(new DefaultSearchSpecification<Claim>(), cancellationToken);

            if (claims.Count == 0)
                return EitherHelper<ClaimGetAllCommandUserCommandResult>.EntityNotFound(typeof(Claim)); 
            
            return new Either<ClaimGetAllCommandUserCommandResult>(new ClaimGetAllCommandUserCommandResult
            {
                Claims = claims,
            });
        }
    }
}