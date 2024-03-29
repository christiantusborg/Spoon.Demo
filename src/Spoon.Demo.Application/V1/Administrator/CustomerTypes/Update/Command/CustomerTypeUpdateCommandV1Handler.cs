namespace Spoon.Demo.Application.V1.Administrator.CustomerTypes.Update.Command;

using Domain.Entities;
using Domain.Repositories;

/// <summary>
///     Class ProductUpdateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class CustomerTypeUpdateCommandV1Handler : IRequestHandler<CustomerTypeUpdateCommandV1, Either<CustomerTypeUpdateCommandV1Result>>
{
    private readonly ICustomerTypeRepository _repository;
    private readonly IMockbleDateTime _mockbleDateTime;

    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="mockbleDateTime"></param>
    public CustomerTypeUpdateCommandV1Handler(IApplicationRepository repository, IMockbleDateTime mockbleDateTime)
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
    /// <returns>Task&lt;Either&lt;ProductUpdateQueryResult&gt;&gt;.</returns>
    public async Task<Either<CustomerTypeUpdateCommandV1Result>> Handle(
        CustomerTypeUpdateCommandV1 request,
        CancellationToken cancellationToken)
    {
        var getSpecification = new DefaultGetSpecification<CustomerType>(request.CustomerTypeId);
        
        var existing = await this._repository.GetAsync(getSpecification, cancellationToken);

        if (existing is null)
            return EitherHelper<CustomerTypeUpdateCommandV1Result>.EntityNotFound(typeof(CustomerTypeUpdateCommandV1));

        existing.Name = request.Name ?? existing.Name;
        existing.Description = request.Description ?? existing.Description;
        existing.ModifiedAt = this._mockbleDateTime.UtcNow;

        await this._repository.SaveChangesAsync(cancellationToken);

        return new Either<CustomerTypeUpdateCommandV1Result>(new CustomerTypeUpdateCommandV1Result());
    }
}
