namespace Spoon.Demo.Application.V1.Administrator.CustomerTypes.Get.V1.Command;

using Domain.Entities;
using Domain.Repositories;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class CustomerTypeGetCommandV1Handler : IRequestHandler<CustomerTypeGetCommandV1, Either<CustomerTypeGetCommandV1Result>>
{
    private readonly ICustomerTypeRepository _repository;

    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    public CustomerTypeGetCommandV1Handler(IApplicationRepository repository)
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
    /// <returns>Task&lt;Either&lt;ProductCreateQueryResult&gt;&gt;.</returns>
    public async Task<Either<CustomerTypeGetCommandV1Result>> Handle(
        CustomerTypeGetCommandV1 request,
        CancellationToken cancellationToken)
    {
        var getSpecification = new DefaultGetSpecification<CustomerType>(request.CustomerTypeId);
        
        var existing = await this._repository.GetAsync(getSpecification, cancellationToken);

        if (existing == null)
            return EitherHelper<CustomerTypeGetCommandV1Result>.EntityNotFound(typeof(CustomerTypeGetCommandV1));

        await this._repository.SaveChangesAsync(cancellationToken);

        var result = new CustomerTypeGetCommandV1Result
        {
            CategoryId = existing.CustomerTypeId,
            Name = existing.Name,
            Description = existing.Description,
            CreatedAt = existing.CreatedAt,
            ModifiedAt = existing.ModifiedAt,
            DeletedAt = existing.DeletedAt,
        };

        return new Either<CustomerTypeGetCommandV1Result>(result);
    }
}