namespace Spoon.Demo.Application.V1.Administrator.Addresses.UnDelete.V1.Command;

using Domain.Entities;
using Domain.Repositories;

/// <summary>
///     Class ProductDeleteQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class AddressUnDeleteCommandV1Handler : IRequestHandler<AddressUnDeleteCommandV1, Either<AddressUnDeleteCommandV1Result>>
{
    private readonly IAddressesRepository _repository;

    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    public AddressUnDeleteCommandV1Handler(IApplicationRepository repository)
    {
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
    /// <returns>Task&lt;Either&lt;ProductDeleteQueryResult&gt;&gt;.</returns>
    public async Task<Either<AddressUnDeleteCommandV1Result>> Handle(
        AddressUnDeleteCommandV1 request,
        CancellationToken cancellationToken)
    {
        var getSpecification = new DefaultGetSpecification<Address>(request.AddressId);

        var existing = await this._repository.GetAsync(getSpecification, cancellationToken);

        if (existing is null)
        {
            return EitherHelper<AddressUnDeleteCommandV1Result>.EntityNotFound(typeof(AddressUnDeleteCommandV1));
        }

        existing.DeletedAt = null;

        await this._repository.SaveChangesAsync(cancellationToken);

        return new Either<AddressUnDeleteCommandV1Result>(new AddressUnDeleteCommandV1Result());
    }
}