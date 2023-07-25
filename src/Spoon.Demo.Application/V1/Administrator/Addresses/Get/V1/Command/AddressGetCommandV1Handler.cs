namespace Spoon.Demo.Application.V1.Administrator.Addresses.Get.V1.Command;

using Domain.Entities;
using Domain.Repositories;
using NuGet.SecureRemotePassword.Helpers;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class AddressGetCommandV1Handler : IRequestHandler<AddressGetCommandV1, Either<AddressGetCommandV1Result>>
{
    private readonly IEncryptionService _encryptionService;
    private readonly IAddressesRepository _repository;

    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="encryptionService"></param>
    public AddressGetCommandV1Handler(IApplicationRepository repository, IEncryptionService encryptionService)
    {
        this._encryptionService = encryptionService;
        this._repository = repository.Addresses;
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
    public async Task<Either<AddressGetCommandV1Result>> Handle(
        AddressGetCommandV1 request,
        CancellationToken cancellationToken)
    {
        var existing = await this._repository.GetAsync(new DefaultGetSpecification<Address>(request.AddressId), cancellationToken);

        if (existing == null)
            return EitherHelper<AddressGetCommandV1Result>.EntityNotFound(typeof(AddressGetCommandV1));

        await this._repository.SaveChangesAsync(cancellationToken);

        var result = new AddressGetCommandV1Result
        {
            AddressId = existing.AddressId,
            City = existing.City,
            Country = existing.Country,
            CustomerId = existing.CustomerId,
            Zip = existing.Zip,
            AddressOne = this._encryptionService.Decrypt(existing.AddressOneEncrypted),
            AddressTwo = existing.AddressTwoEncrypted != null ? this._encryptionService.Decrypt(existing.AddressTwoEncrypted) : null,
            AddressTypeId = existing.AddressTypeId,
            CreatedAt = existing.CreatedAt,
            ModifiedAt = existing.ModifiedAt,
            DeletedAt = existing.DeletedAt,
        };

        return new Either<AddressGetCommandV1Result>(result);
    }
}