namespace Spoon.Demo.Application.V1.Administrator.Categories.Delete.V1.Command;

/// <summary>
///     Class ProductDeleteQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class CategoryDeleteCommandV1 : MediatorBaseCommand, IHandleableRequest<CategoryDeleteCommandV1,
    CategoryDeleteCommandV1Handler,
    Either<CategoryDeleteCommandV1Result>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="CategoryDeleteCommandV1" /> class.
    /// </summary>
    public CategoryDeleteCommandV1()
        : base(typeof(CategoryDeleteCommandV1))
    {
    }

    /// <summary>
    ///     Gets or sets the product identifier.
    /// </summary>
    /// <value>The product identifier.</value>
    public required Guid CategoryId { get; set; }
}