namespace Spoon.Demo.Application.V1.Administrator.Addresses.Create.V1.Command;

using Domain.Entities;
using Domain.Repositories;
using NuGet.SecureRemotePassword.Helpers;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class AddressCreateCommandV1Handler : IRequestHandler<AddressCreateCommandV1, Either<AddressCreateCommandV1Result>>
{
    private readonly IAddressesRepository _repository;
    private readonly IMockbleGuidGenerator _mockbleGuidGenerator;
    private readonly IMockbleDateTime _mockbleDateTime;
    private readonly IEncryptionService _encryptionService;

    /// <summary>
    ///     Initializes a new instance of the <see cref="AddressCreateCommandV1Handler" /> class.
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="mockbleGuidGenerator"></param>
    /// <param name="mockbleDateTime"></param>
    /// <param name="encryptionService"></param>
    public AddressCreateCommandV1Handler(IApplicationRepository repository, IMockbleGuidGenerator mockbleGuidGenerator, IMockbleDateTime mockbleDateTime, IEncryptionService encryptionService)
    {
        this._repository = repository.Addresses;

        this._mockbleGuidGenerator = mockbleGuidGenerator;
        this._mockbleDateTime = mockbleDateTime;
        this._encryptionService = encryptionService;
    }

    /// <summary>
    ///     Handles the specified request.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Either<AddressCreateCommandV1Result>> Handle(
        AddressCreateCommandV1 request,
        CancellationToken cancellationToken)
    {
        var getSpecification = new DefaultGetSpecification<Address>(request.CustomerId);
        
        var existing = await this._repository.GetAsync(getSpecification, cancellationToken);

        if (existing is not null)
            return EitherHelper<AddressCreateCommandV1Result>.EntityAlreadyExists(typeof(AddressCreateCommandV1));

        var newGuid = this._mockbleGuidGenerator.NewId();

        var next = new Address
        {
            AddressId = newGuid,
            City = request.City,
            Country = request.Country,
            CustomerId = request.CustomerId,
            Zip = request.Zip,
            AddressOneEncrypted = this._encryptionService.Encrypt(request.AddressOne),
            AddressTwoEncrypted = request.AddressTwo != null ? this._encryptionService.Encrypt(request.AddressTwo) : null,
            AddressTypeId = request.AddressTypeId,
            CreatedAt = this._mockbleDateTime.UtcNow,
            ModifiedAt = this._mockbleDateTime.UtcNow,
            DeletedAt = null,
        };

        this._repository.Add(next);

        await this._repository.SaveChangesAsync(cancellationToken);

        var result = new AddressCreateCommandV1Result
        {
            AddressId = newGuid,
        };

        return new Either<AddressCreateCommandV1Result>(result);
    }
}