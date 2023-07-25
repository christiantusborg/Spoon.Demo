namespace Spoon.Demo.Application.V1.Administrator.CustomerTypes.Delete.V1.Command;

using Domain.Entities;
using Domain.Repositories;

/// <summary>
///     Class ProductDeleteQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class CustomerTypeDeleteCommandV1Handler : IRequestHandler<CustomerTypeDeleteCommandV1, Either<CustomerTypeDeleteCommandV1Result>>
{
    private readonly ICustomerTypeRepository _repository;
    private readonly IMockbleDateTime _mockbleDateTime;


    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="mockbleDateTime"></param>
    public CustomerTypeDeleteCommandV1Handler(IApplicationRepository repository, IMockbleDateTime mockbleDateTime)
    {
        this._repository = repository.CustomerTypes;
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
    public async Task<Either<CustomerTypeDeleteCommandV1Result>> Handle(
        CustomerTypeDeleteCommandV1 request,
        CancellationToken cancellationToken)
    {
        var getSpecification = new DefaultGetSpecification<CustomerType>(request.CustomerTypeId);
        
        var exiting = await this._repository.GetAsync(getSpecification, cancellationToken);

        if (exiting is null)
        {
            return EitherHelper<CustomerTypeDeleteCommandV1Result>.EntityNotFound(typeof(CustomerTypeDeleteCommandV1));
        }

        exiting.DeletedAt = this._mockbleDateTime.UtcNow;

        await this._repository.SaveChangesAsync(cancellationToken);

        return new Either<CustomerTypeDeleteCommandV1Result>(new CustomerTypeDeleteCommandV1Result());
    }
}