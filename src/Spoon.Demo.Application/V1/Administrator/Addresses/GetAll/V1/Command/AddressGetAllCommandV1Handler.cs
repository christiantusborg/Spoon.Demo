// ReSharper disable ClassNeverInstantiated.Global

namespace Spoon.Demo.Application.V1.Administrator.Addresses.GetAll.V1.Command;

using Domain.Entities;
using Domain.Repositories;
using NuGet.SecureRemotePassword.Helpers;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class AddressGetAllCommandV1Handler : IRequestHandler<AddressGetAllCommandV1, Either<BaseSearchCommandResult<AddressGetAllCommandV1Result>>>
{
    private readonly IEncryptionService _encryptionService;
    private readonly IAddressesRepository _repository;

    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="encryptionService"></param>
    public AddressGetAllCommandV1Handler(IApplicationRepository repository, IEncryptionService encryptionService)
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
    public async Task<Either<BaseSearchCommandResult<AddressGetAllCommandV1Result>>> Handle(
        AddressGetAllCommandV1 request,
        CancellationToken cancellationToken)
    {
        var searchSpecification = new DefaultSearchSpecification<Address>(request.Filters, request.SortField, request.Skip, request.Take, request.IncludeDeleted);
        
        var existing = await this._repository.SearchAsync(searchSpecification, cancellationToken);

        if (existing.Count == 0)
            return new Either<BaseSearchCommandResult<AddressGetAllCommandV1Result>>(new BaseSearchCommandResult<AddressGetAllCommandV1Result>());

        var total = await this._repository.CountAsync(searchSpecification, cancellationToken);

        var result = new BaseSearchCommandResult<AddressGetAllCommandV1Result>
        {
            Items = existing.Select(x => new AddressGetAllCommandV1Result
            {
                AddressId = x.AddressId,
                City = x.City,
                Country = x.Country,
                CustomerId = x.CustomerId,
                Zip = x.Zip,
                AddressOne = this._encryptionService.Decrypt(x.AddressOneEncrypted),
                AddressTwo = x.AddressTwoEncrypted != null ? this._encryptionService.Decrypt(x.AddressTwoEncrypted) : null,
                AddressTypeId = x.AddressTypeId,
                CreatedAt = x.CreatedAt,
                ModifiedAt = x.ModifiedAt,
                DeletedAt = x.DeletedAt,
            }).ToList(),
            Total = total,
        };

        return new Either<BaseSearchCommandResult<AddressGetAllCommandV1Result>>(result);
    }
}