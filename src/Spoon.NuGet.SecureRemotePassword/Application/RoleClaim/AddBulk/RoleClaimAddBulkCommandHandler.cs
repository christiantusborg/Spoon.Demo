namespace Spoon.NuGet.SecureRemotePassword.Application.RoleClaim.AddBulk
{
    using MediatR;
    using Spoon.NuGet.Core;
    using Spoon.NuGet.EitherCore;

    /// <summary>
    ///     Class ProductCreateQueryHandler. This class cannot be inherited.
    /// </summary>
    public sealed class RoleClaimAddBulkCommandHandler : IRequestHandler<RoleClaimAddBulkCommand, Either<RoleClaimAddBulkCommandResult>>
    {

        private readonly IMockbleGuidGenerator _mockbleGuidGenerator;

        /// <summary>
        /// </summary>
        /// <param name="writeRepository"></param>
        /// <param name="mockbleGuidGenerator"></param>
        public RoleClaimAddBulkCommandHandler(IMockbleGuidGenerator mockbleGuidGenerator)
        {
            this._mockbleGuidGenerator = mockbleGuidGenerator;
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
        public async Task<Either<RoleClaimAddBulkCommandResult>> Handle(
            RoleClaimAddBulkCommand request,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            return new Either<RoleClaimAddBulkCommandResult>(new RoleClaimAddBulkCommandResult());
        }
    }
}