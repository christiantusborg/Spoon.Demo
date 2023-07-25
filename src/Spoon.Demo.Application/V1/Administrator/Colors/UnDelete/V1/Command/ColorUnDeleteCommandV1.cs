namespace Spoon.Demo.Application.V1.Administrator.Colors.UnDelete.V1.Command;

/// <summary>
///     Class ProductDeleteQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class ColorUnDeleteCommandV1 : MediatorBaseCommand, IHandleableRequest<ColorUnDeleteCommandV1,
    ColorUnDeleteCommandV1Handler,
    Either<ColorUnDeleteCommandV1Result>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ColorUnDeleteCommandV1" /> class.
    /// </summary>
    public ColorUnDeleteCommandV1()
        : base(typeof(ColorUnDeleteCommandV1))
    {
    }

    /// <inheritdoc cref="MediatorBaseCommand" />
    public required Guid ColorId { get; set; }
}