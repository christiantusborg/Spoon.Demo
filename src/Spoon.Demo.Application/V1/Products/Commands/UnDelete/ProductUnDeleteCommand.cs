namespace Spoon.Demo.Application.V1.Products.Commands.UnDelete;

using NuGet.Core.Application;
using NuGet.Core.Application.Interfaces;
using NuGet.Core.EitherCore;

/// <summary>
///     Class ProductDeleteQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
public sealed class ProductUnDeleteCommand : MediatorBaseCommand, IHandleableRequest<ProductUnDeleteCommand,
    ProductUnDeleteCommandHandler,
    Either<ProductUnDeleteCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ProductUnDeleteCommand" /> class.
    /// </summary>
    public ProductUnDeleteCommand()
        : base(typeof(ProductUnDeleteCommand))
    {
    }

    /// <summary>
    ///     Gets or sets the product identifier.
    /// </summary>
    /// <value>The product identifier.</value>
    public Guid ProductId { get; set; }
}