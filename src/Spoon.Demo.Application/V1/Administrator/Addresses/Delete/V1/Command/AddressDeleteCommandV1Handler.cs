namespace Spoon.Demo.Application.V1.Administrator.Addresses.Delete.V1.Command;

using Domain.Entities;
using Domain.Repositories;

/// <summary>
///     Class ProductDeleteQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class AddressDeleteCommandV1Handler : IRequestHandler<AddressDeleteCommandV1, Either<AddressDeleteCommandV1Result>>
{
    private readonly IAddressesRepository _repository;
    private readonly IMockbleDateTime _mockbleDateTime;


    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="mockbleDateTime"></param>
    public AddressDeleteCommandV1Handler(IApplicationRepository repository, IMockbleDateTime mockbleDateTime)
    {
        this._repository = repository.Addresses;
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
    /// <returns>Task&lt;Either&lt;ProductDeleteQueryResult&gt;&gt;.</returns>
    public async Task<Either<AddressDeleteCommandV1Result>> Handle(
        AddressDeleteCommandV1 request,
        CancellationToken cancellationToken)
    {
        var existing = await this._repository.GetAsync(new DefaultGetSpecification<Address>(request.AddressId), cancellationToken);

        if (existing is null)
        {
            return EitherHelper<AddressDeleteCommandV1Result>.EntityNotFound(typeof(AddressDeleteCommandV1));
        }

        existing.DeletedAt = this._mockbleDateTime.UtcNow;

        await this._repository.SaveChangesAsync(cancellationToken);

        return new Either<AddressDeleteCommandV1Result>(new AddressDeleteCommandV1Result());
    }
}