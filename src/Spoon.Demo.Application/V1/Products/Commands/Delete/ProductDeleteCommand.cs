namespace Spoon.Demo.Application.V1.Products.Commands.Delete;

using NuGet.Core.Application;
using NuGet.Core.Application.Interfaces;
using NuGet.Core.EitherCore;

/// <summary>
///     Class ProductDeleteQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
public sealed class ProductDeleteCommand : MediatorBaseCommand, IHandleableRequest<ProductDeleteCommand,
    ProductDeleteCommandHandler,
    Either<ProductDeleteCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ProductDeleteCommand" /> class.
    /// </summary>
    public ProductDeleteCommand()
        : base(typeof(ProductDeleteCommand))
    {
    }

    /// <summary>
    ///     Gets or sets the product identifier.
    /// </summary>
    /// <value>The product identifier.</value>
    public Guid ProductId { get; set; }
}