#pragma warning disable CS8618
namespace Spoon.Demo.Application.V1.Administrator.Categories.Create.V1.Command;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class CategoryCreateCommandV1 : MediatorBaseCommand, IHandleableRequest<CategoryCreateCommandV1, CategoryCreateCommandV1Handler, Either<CategoryCreateCommandV1Result>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="CategoryCreateCommandV1" /> class.
    ///     Handled by <see cref="CategoryCreateCommandV1Handler" /> class.
    /// </summary>
    public CategoryCreateCommandV1() : base(typeof(CategoryCreateCommandV1))
    {
    }

    /// <inheritdoc cref="CategoryCreateCommandV1" />
    public required string Name { get; init; }

    /// <inheritdoc cref="CategoryCreateCommandV1" />
    public required string Description { get; init; }

    /// <inheritdoc cref="CategoryCreateCommandV1" />
    public required int Discount { get; init; }

    /// <inheritdoc cref="CategoryCreateCommandV1" />
    public required int ProfitMargin { get; init; }
}