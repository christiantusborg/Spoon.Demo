namespace Spoon.Demo.Application.V1.Administrator.CustomerTypes.UnDelete.V1.Command;

using Domain.Entities;
using Domain.Repositories;

/// <summary>
///     Class ProductDeleteQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class CustomerTypeUnDeleteCommandV1Handler : IRequestHandler<CustomerTypeUnDeleteCommandV1, Either<CustomerTypeUnDeleteCommandV1Result>>
{
    private readonly ICustomerTypeRepository _repository;

    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    public CustomerTypeUnDeleteCommandV1Handler(IApplicationRepository repository)
    {
        this._repository = repository.CustomerTypes;
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
    public async Task<Either<CustomerTypeUnDeleteCommandV1Result>> Handle(
        CustomerTypeUnDeleteCommandV1 request,
        CancellationToken cancellationToken)
    {
        var getSpecification = new DefaultGetSpecification<CustomerType>(request.CustomerTypeId);
        var existing = await this._repository.GetAsync(getSpecification, cancellationToken);

        if (existing is null)
        {
            return EitherHelper<CustomerTypeUnDeleteCommandV1Result>.EntityNotFound(typeof(CustomerTypeUnDeleteCommandV1));
        }

        existing.DeletedAt = null;

        await this._repository.SaveChangesAsync(cancellationToken);

        return new Either<CustomerTypeUnDeleteCommandV1Result>(new CustomerTypeUnDeleteCommandV1Result());
    }
}