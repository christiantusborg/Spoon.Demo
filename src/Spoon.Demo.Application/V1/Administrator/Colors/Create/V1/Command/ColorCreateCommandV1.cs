#pragma warning disable CS8618
namespace Spoon.Demo.Application.V1.Administrator.Colors.Create.V1.Command;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class ColorCreateCommandV1 : MediatorBaseCommand, IHandleableRequest<ColorCreateCommandV1, ColorCreateCommandV1Handler, Either<ColorCreateCommandV1Result>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ColorCreateCommandV1" /> class.
    ///     Handled by <see cref="ColorCreateCommandV1Handler" /> class.
    /// </summary>
    public ColorCreateCommandV1() : base(typeof(ColorCreateCommandV1))
    {
    }

    /// <inheritdoc cref="ColorCreateCommandV1" />
    public required string Name { get; init; }

    /// <inheritdoc cref="ColorCreateCommandV1" />
    public required string Description { get; init; }

    /// <inheritdoc cref="ColorCreateCommandV1" />
    public required int Discount { get; init; }

    /// <inheritdoc cref="ColorCreateCommandV1" />
    public required int ProfitMargin { get; init; }
}