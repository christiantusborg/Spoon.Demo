namespace Spoon.Demo.Application.V1.Addresses.Create
{
    using Domain.Entities;
    using Domain.Repositories;
    using MediatR;
    using Spoon.NuGet.Core;
    using Spoon.NuGet.EitherCore;
    using Spoon.NuGet.EitherCore.Helpers;
    using Spoon.NuGet.SecureRemotePassword.Application.SharedSpecification;
    using Spoon.NuGet.SecureRemotePassword.Domain.Entities;
    using Spoon.NuGet.SecureRemotePassword.Domain.Repositories;
    using Spoon.NuGet.SecureRemotePassword.Helpers;

    /// <summary>
    /// Handles the creation of a new user.
    /// </summary>
    public sealed class AddressesCreateCommandHandler : IRequestHandler<AddressesCreateCommand, Either<AddressesCreateCommandResult>>
    {

        private readonly IMockbleGuidGenerator _mockbleGuidGenerator;
        private readonly IMockbleDateTime _mockbleDateTime;
        private readonly IApplicationRepository _repository;
        private readonly IEncryptionService _encryptionService;
        private readonly IHashService _hashService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressesCreateCommandHandler"/> class.
        /// </summary>
        /// <param name="mockbleGuidGenerator">A mockable GUID generator.</param>
        /// <param name="mockbleDateTime">A mockable date/time service.</param>
        /// <param name="repository">The repository for secure remote password data.</param>
        /// <param name="encryptionService">The encryption service.</param>
        /// <param name="hashService">The hash service.</param>
        public AddressesCreateCommandHandler(IMockbleGuidGenerator mockbleGuidGenerator,
            IMockbleDateTime mockbleDateTime,
            IApplicationRepository repository,
            IEncryptionService encryptionService,
            IHashService hashService)
        {
            this._mockbleGuidGenerator = mockbleGuidGenerator;
            this._mockbleDateTime = mockbleDateTime;
            this._repository = repository;
            this._encryptionService = encryptionService;
            this._hashService = hashService;
        }

        /// <summary>
        /// Handles the request to create a new user.
        /// </summary>
        /// <param name="request">The request to create a new user.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>An <see>
        ///         <cref>Either{TLeft, TRight}</cref>
        ///     </see>
        ///     containing either the result of the user creation or an error.</returns>
        public async Task<Either<AddressesCreateCommandResult>> Handle(
            AddressesCreateCommand request,
            CancellationToken cancellationToken)
        {
            var addressId = this._mockbleGuidGenerator.NewGuid();
            
            var address = new Address
            {
                CustomerId = request.CustomerId,
                AddressId  = addressId,
                AddressOneEncrypted = request.AddressOne,
                AddressTwoEncrypted = request.AddressTwo,
                AddressTypeId = request.AddressTypeId,
                Zip = request.Zip,  
                City = request.City,
                Country = request.Country,
                CreatedAt = this._mockbleDateTime.UtcNow,
                ModifiedAt = this._mockbleDateTime.UtcNow,
            };
            
            this._repository.Addresses.Add(address);
            await this._repository.SaveChangesAsync(cancellationToken);
            
            return new Either<AddressesCreateCommandResult>(new AddressesCreateCommandResult
                {
                   Success = true,
                }
            );
        }
    }
}