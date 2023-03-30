namespace Spoon.Demo.Application.V1.Products.Queries.Search;

using Domain.Repositories;
using Mapster;
using MediatR;
using NuGet.Core.Domain;
using NuGet.EitherCore;
using NuGet.EitherCore.Helpers;

/// <summary>
/// Class ProductSearchQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class ProductSearchQueryHandler : IRequestHandler<ProductSearchQuery, Either<ProductSearchQueryResult>>
{

    private readonly IReadOnlyRepository _readOnlyRepository;

    /// <summary>
    /// </summary>
    /// <param name="readOnlyRepository"></param>
    public ProductSearchQueryHandler(IReadOnlyRepository readOnlyRepository )
    {
        this._readOnlyRepository = readOnlyRepository;
    }
    
    
    /// <summary>
    /// Handles the specified request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Task&lt;Either&lt;ProductSearchQueryResult&gt;&gt;.</returns>
    public async Task<Either<ProductSearchQueryResult>> Handle(
        ProductSearchQuery request,
        CancellationToken cancellationToken)
    {

        var ble = new List<Filter>
        {
            new Filter
            {
                Operation = Operation.StartsWith,
                Value = "Chr",
                PropertyName = "Name",
            },
            new Filter
            {
                Operation = Operation.Equals,
                Value = "Tusborg",
                PropertyName = "LastName",
                
            }
        };
        
           
 var product = await this._readOnlyRepository.Products.GetAllAsync(new SearchSpecification(request.Filters,request.Skip,request.Take), cancellationToken);

        if (product is null)
            return EitherHelper<ProductSearchQueryResult>.EntityNotFound(typeof(ProductSearchQuery));

        var result = product.Adapt<ProductSearchQueryResult>();

        return new Either<ProductSearchQueryResult>(result);
    }
}
