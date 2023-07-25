#pragma warning disable CS8618
namespace Spoon.Demo.Application.V1.Administrator.Colors.Update.Command;

/// <summary>
///     Class ProductUpdateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class ColorUpdateCommandV1 : MediatorBaseCommand, IHandleableRequest<ColorUpdateCommandV1,
    ColorUpdateCommandV1Handler,
    Either<ColorUpdateCommandV1Result>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ColorUpdateCommandV1" /> class.
    /// </summary>
    public ColorUpdateCommandV1()
        : base(typeof(ColorUpdateCommandV1))
    {
    }

    /// <inheritdoc cref="MediatorBaseCommand" />
    public required Guid ColorId { get; init; }

    /// <inheritdoc cref="ColorUpdateCommandV1" />
    public string? Name { get; init; }

    /// <inheritdoc cref="ColorUpdateCommandV1" />
    public string? Description { get; init; }

}