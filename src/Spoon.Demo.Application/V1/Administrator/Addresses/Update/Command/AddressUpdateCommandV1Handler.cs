namespace Spoon.Demo.Application.V1.Administrator.Addresses.Update.Command;

using Domain.Entities;
using Domain.Repositories;
using NuGet.SecureRemotePassword.Helpers;

/// <summary>
///     Class ProductUpdateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class AddressUpdateCommandV1Handler : IRequestHandler<AddressUpdateCommandV1, Either<AddressUpdateCommandV1Result>>
{
    private readonly IAddressesRepository _repository;
    private readonly IMockbleDateTime _mockbleDateTime;
    private readonly IEncryptionService _encryptionService;

    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="mockbleDateTime"></param>
    /// <param name="encryptionService"></param>
    public AddressUpdateCommandV1Handler(IApplicationRepository repository, IMockbleDateTime mockbleDateTime, IEncryptionService encryptionService)
    {
        this._repository = repository.Addresses;
        this._mockbleDateTime = mockbleDateTime;
        this._encryptionService = encryptionService;
    }

    /// <summary>
    ///     Handles the specified request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="cancellationToken">
    ///     The cancellation token that can be used by other objects or threads to receive notice
    ///     of cancellation.
    /// </param>
    /// <returns>Task&lt;Either&lt;ProductUpdateQueryResult&gt;&gt;.</returns>
    public async Task<Either<AddressUpdateCommandV1Result>> Handle(
        AddressUpdateCommandV1 request,
        CancellationToken cancellationToken)
    {
        var getSpecification = new DefaultGetSpecification<Address>(request.AddressId);
        var existing = await this._repository.GetAsync(getSpecification, cancellationToken);

        if (existing is null)
            return EitherHelper<AddressUpdateCommandV1Result>.EntityNotFound(typeof(AddressUpdateCommandV1));

        existing.City = request.City ?? existing.City;
        existing.Country = request.Country ?? existing.Country;
        existing.Zip = request.Zip ?? existing.Zip;
        existing.CustomerId = request.CustomerId ?? existing.CustomerId;
        existing.AddressOneEncrypted = request.AddressOne != null ? this._encryptionService.Encrypt(request.AddressOne) : existing.AddressOneEncrypted;
        existing.AddressTwoEncrypted = request.AddressTwo != null ? this._encryptionService.Encrypt(request.AddressTwo) : existing.AddressTwoEncrypted;
        existing.AddressTypeId = request.AddressTypeId ?? existing.AddressTypeId;

        existing.ModifiedAt = this._mockbleDateTime.UtcNow;

        await this._repository.SaveChangesAsync(cancellationToken);

        return new Either<AddressUpdateCommandV1Result>(new AddressUpdateCommandV1Result());
    }
}