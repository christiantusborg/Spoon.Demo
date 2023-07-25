// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Spoon.Demo.Application.V1.Administrator.Categories.Get.V1.Command;

/// <summary>
///     Class ProductCreateQueryResult. This class cannot be inherited.
/// </summary>
public sealed class CategoryGetCommandV1Result
{
    /// <inheritdoc cref="CategoryGetCommandV1Result" />
    public required Guid CategoryId { get; set; }

    /// <inheritdoc cref="CategoryGetCommandV1Result" />
    public required string Name { get; set; }

    /// <inheritdoc cref="CategoryGetCommandV1Result" />
    public required string Description { get; set; }

    /// <inheritdoc cref="CategoryGetCommandV1Result" />
    public required int Discount { get; set; }

    /// <inheritdoc cref="CategoryGetCommandV1Result" />
    public required int ProfitMargin { get; set; }

    /// <inheritdoc cref="CategoryGetCommandV1Result" />
    public required DateTime CreatedAt { get; set; }

    /// <inheritdoc cref="CategoryGetCommandV1Result" />
    public required DateTime ModifiedAt { get; set; }

    /// <inheritdoc cref="CategoryGetCommandV1Result" />
    public required DateTime? DeletedAt { get; set; }
}