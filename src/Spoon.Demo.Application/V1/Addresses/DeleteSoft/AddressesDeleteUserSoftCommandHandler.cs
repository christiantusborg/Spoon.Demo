namespace Spoon.Demo.Application.V1.Addresses.DeleteSoft
{
    using MediatR;
    using Spoon.NuGet.Core;
    using Spoon.NuGet.Core.Application;
    using Spoon.NuGet.EitherCore;
    using Spoon.NuGet.EitherCore.Enums;
    using Spoon.NuGet.EitherCore.Helpers;
    using Spoon.NuGet.SecureRemotePassword.Domain.Entities;
    using Spoon.NuGet.SecureRemotePassword.Domain.Repositories;

    /// <summary>
    ///     Class ProductCreateQueryHandler. This class cannot be inherited.
    /// </summary>
    public sealed class AddressesDeleteUserSoftCommandHandler : IRequestHandler<AddressesDeleteUserSoftCommand, Either<AddressesDeleteUserSoftCommandResult>>
    {
        private readonly ISecureRemotePasswordRepository _repository;
        private readonly IMockbleDateTime _mockbleDateTime;


        /// <summary>
        /// </summary>
        /// <param name="writeRepository"></param>
        /// <param name="mockbleGuidGenerator"></param>
        public AddressesDeleteUserSoftCommandHandler(ISecureRemotePasswordRepository repository, IMockbleDateTime mockbleDateTime)
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
        public async Task<Either<AddressesDeleteUserSoftCommandResult>> Handle(
            AddressesDeleteUserSoftCommand request,
            CancellationToken cancellationToken)
        {
            var existingUser = await this._repository.Users.GetAsync(new DefaultGetSpecification<User>(request.UserId), cancellationToken);
            if (existingUser == null)
                return EitherHelper<AddressesDeleteUserSoftCommandResult>.EntityNotFound(typeof(User)); 
            
            if(request.UserId == request.CurrentUserId)
                return EitherHelper<AddressesDeleteUserSoftCommandResult>.Create("BadPermissions_CannotDeleteYourself",BaseHttpStatusCodes.Status403Forbidden);
            
            existingUser.DeletedAt = this._mockbleDateTime.UtcNow;
            
            await this._repository.SaveChangesAsync(cancellationToken);
            
            return new Either<AddressesDeleteUserSoftCommandResult>(new AddressesDeleteUserSoftCommandResult());
        }
    }
}