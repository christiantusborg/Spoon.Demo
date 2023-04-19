namespace Spoon.Demo.Application.V1.Products.Queries.Get;

using NuGet.Core.Application;
using NuGet.Core.Application.Interfaces;
using NuGet.Core.EitherCore;

/// <summary>
///     Class ProductGetQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
public sealed class ProductGetQuery : MediatorBaseCommand, IHandleableRequest<ProductGetQuery,
    ProductGetQueryHandler, Either<ProductGetQueryResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ProductGetQuery" /> class.
    /// </summary>
    public ProductGetQuery()
        : base(typeof(ProductGetQuery))
    {
    }

    /// <summary>
    ///     Gets or sets the product identifier.
    /// </summary>
    /// <value>The product identifier.</value>
    public Guid ProductId { get; set; }

    /// <summary>
    /// </summary>
    public string? Name { get; set; }
}