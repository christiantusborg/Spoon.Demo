namespace Spoon.Demo.Application.V1.Products.Commands.DeletePermanent;

using NuGet.Core.Application;
using NuGet.Core.Application.Interfaces;
using NuGet.Core.EitherCore;

/// <summary>
///     Class ProductDeletePermanentQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseQuery" />.
/// </summary>
/// <seealso cref="MediatorBaseQuery" />
public sealed class ProductDeletePermanentCommand : MediatorBaseCommand, IHandleableRequest<ProductDeletePermanentCommand,
    ProductDeletePermanentCommandHandler,
    Either<ProductDeletePermanentCommandResult>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ProductDeletePermanentCommand" /> class.
    /// </summary>
    public ProductDeletePermanentCommand()
        : base(typeof(ProductDeletePermanentCommand))
    {
    }

    /// <summary>
    ///     Gets or sets the product identifier.
    /// </summary>
    /// <value>The product identifier.</value>
    public Guid ProductId { get; set; }
}