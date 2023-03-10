namespace Spoon.Demo.Application.V1.Products.Queries.Search;

using NuGet.EitherCore;
using NuGet.Mediator;
using NuGet.Mediator.Interfaces;

/// <summary>
/// Class ProductSearchQuery. This class cannot be inherited.
/// Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />

public sealed class ProductSearchQuery : MediatorBaseQueryWithSearchAndPagination, IHandleableRequest<ProductSearchQuery,
    ProductSearchQueryHandler,
    Either<ProductSearchQueryResult>>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductSearchQuery"/> class.
    /// </summary>
    public ProductSearchQuery()
        : base(typeof(ProductSearchQuery))
    {
    }

    /// <summary>
    /// Gets or sets the product identifier.
    /// </summary>
    /// <value>The product identifier.</value>
    public Guid ProductId { get; set; }
}