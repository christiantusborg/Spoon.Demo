// ReSharper disable ClassNeverInstantiated.Global

namespace Spoon.Demo.Application.V1.Administrator.CustomerTypes.GetAll.V1.Command;

using Domain.Entities;
using Domain.Repositories;
using NuGet.Core.Domain;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class CustomerTypeGetAllCommandV1Handler : IRequestHandler<CustomerTypeGetAllCommandV1, Either<BaseSearchCommandResult<CustomerTypeGetAllCommandV1Result>>>
{
    private readonly ICustomerTypeRepository _repository;

    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    public CustomerTypeGetAllCommandV1Handler(IApplicationRepository repository)
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
    public async Task<Either<BaseSearchCommandResult<CustomerTypeGetAllCommandV1Result>>> Handle(
        CustomerTypeGetAllCommandV1 request,
        CancellationToken cancellationToken)
    {
        var searchSpecification = new DefaultSearchSpecification<CustomerType>(request.Filters.ToList(), new List<Sorting>(), request.Skip, request.Take, request.IncludeDeleted);
        
        var existing = await this._repository.SearchAsync(searchSpecification, cancellationToken);

        if (existing.Count == 0)
            return new Either<BaseSearchCommandResult<CustomerTypeGetAllCommandV1Result>>(new BaseSearchCommandResult<CustomerTypeGetAllCommandV1Result>());

        var total = await this._repository.CountAsync(searchSpecification, cancellationToken);

        var result = new BaseSearchCommandResult<CustomerTypeGetAllCommandV1Result>
        {
            Items = existing.Select(x => new CustomerTypeGetAllCommandV1Result
            {
                CustomerTypeId = x.CustomerTypeId,
                Name = x.Name,
                Description = x.Description,
                
                CreatedAt = x.CreatedAt,
                ModifiedAt = x.ModifiedAt,
                DeletedAt = x.DeletedAt,
            }).ToList(),
            Total = total,
        };

        return new Either<BaseSearchCommandResult<CustomerTypeGetAllCommandV1Result>>(result);
    }
}