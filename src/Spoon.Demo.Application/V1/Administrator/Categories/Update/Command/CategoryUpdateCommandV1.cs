#pragma warning disable CS8618
namespace Spoon.Demo.Application.V1.Administrator.Categories.Update.Command;

/// <summary>
///     Class ProductUpdateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class CategoryUpdateCommandV1 : MediatorBaseCommand, IHandleableRequest<CategoryUpdateCommandV1,
    CategoryUpdateCommandV1Handler,
    Either<CategoryUpdateCommandV1Result>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="CategoryUpdateCommandV1" /> class.
    /// </summary>
    public CategoryUpdateCommandV1()
        : base(typeof(CategoryUpdateCommandV1))
    {
    }

    /// <inheritdoc cref="MediatorBaseCommand" />
    public required Guid CategoryId { get; init; }

    /// <inheritdoc cref="CategoryUpdateCommandV1" />
    public string? Name { get; init; }

    /// <inheritdoc cref="CategoryUpdateCommandV1" />
    public string? Description { get; init; }

    /// <inheritdoc cref="CategoryUpdateCommandV1" />
    public int? Discount { get; init; }

    /// <inheritdoc cref="CategoryUpdateCommandV1" />
    public int? ProfitMargin { get; init; }
}