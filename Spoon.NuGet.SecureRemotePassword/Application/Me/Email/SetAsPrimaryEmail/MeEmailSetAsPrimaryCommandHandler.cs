namespace Spoon.NuGet.SecureRemotePassword.Application.Me.Email.SetAsPrimaryEmail
{
    using MediatR;
    using Spoon.NuGet.Core;
    using Spoon.NuGet.EitherCore;

    /// <summary>
    ///     Class ProductCreateQueryHandler. This class cannot be inherited.
    /// </summary>
    public sealed class MeEmailSetAsPrimaryCommandHandler : IRequestHandler<MeEmailSetAsPrimaryCommand, Either<MeEmailSetAsPrimaryCommandResult>>
    {

        private readonly IMockbleGuidGenerator _mockbleGuidGenerator;

        /// <summary>
        /// </summary>
        /// <param name="writeRepository"></param>
        /// <param name="mockbleGuidGenerator"></param>
        public MeEmailSetAsPrimaryCommandHandler(IMockbleGuidGenerator mockbleGuidGenerator)
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
        public async Task<Either<MeEmailSetAsPrimaryCommandResult>> Handle(
            MeEmailSetAsPrimaryCommand request,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            return new Either<MeEmailSetAsPrimaryCommandResult>(new MeEmailSetAsPrimaryCommandResult());
        }
    }
}