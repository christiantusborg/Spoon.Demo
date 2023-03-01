namespace Spoon.Demo.Application.V1.Products.Commands.Update;

using NuGet.EitherCore;
using NuGet.Mediator;
using NuGet.Mediator.Interfaces;

/// <summary>
/// Class ProductUpdateQuery. This class cannot be inherited.
/// Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
public sealed class ProductUpdateCommand : MediatorBaseCommand, IHandleableRequest<ProductUpdateCommand,
    ProductUpdateCommandHandler,
    Either<ProductUpdateCommandResult>>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProductUpdateCommand"/> class.
    /// </summary>
    public ProductUpdateCommand()
        : base(typeof(ProductUpdateCommand))
    {
    }

    /// <summary>
    /// Gets or sets the product identifier.
    /// </summary>
    /// <value>The product identifier.</value>
    public Guid ProductId { get; set; }

    /// <summary>
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// </summary>
    public string? Sku { get; set; }
}