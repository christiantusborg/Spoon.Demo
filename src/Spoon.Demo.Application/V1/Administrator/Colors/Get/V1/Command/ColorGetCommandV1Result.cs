// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Spoon.Demo.Application.V1.Administrator.Colors.Get.V1.Command;

/// <summary>
///     Class ProductCreateQueryResult. This class cannot be inherited.
/// </summary>
public sealed class ColorGetCommandV1Result
{
    /// <inheritdoc cref="ColorGetCommandV1Result" />
    public required Guid ColorId { get; set; }

    /// <inheritdoc cref="ColorGetCommandV1Result" />
    public required string Name { get; set; }

    /// <inheritdoc cref="ColorGetCommandV1Result" />
    public required string Description { get; set; }

    /// <inheritdoc cref="ColorGetCommandV1Result" />
    public required DateTime CreatedAt { get; set; }

    /// <inheritdoc cref="ColorGetCommandV1Result" />
    public required DateTime ModifiedAt { get; set; }

    /// <inheritdoc cref="ColorGetCommandV1Result" />
    public required DateTime? DeletedAt { get; set; }
}