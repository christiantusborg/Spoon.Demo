namespace Spoon.Demo.Application.V1.Administrator.Categories.UnDelete.V1.Command;

/// <summary>
///     Class ProductDeleteQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class CategoryUnDeleteCommandV1 : MediatorBaseCommand, IHandleableRequest<CategoryUnDeleteCommandV1,
    CategoryUnDeleteCommandV1Handler,
    Either<CategoryUnDeleteCommandV1Result>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="CategoryUnDeleteCommandV1" /> class.
    /// </summary>
    public CategoryUnDeleteCommandV1()
        : base(typeof(CategoryUnDeleteCommandV1))
    {
    }

    /// <inheritdoc cref="MediatorBaseCommand" />
    public required Guid CategoryId { get; set; }
}