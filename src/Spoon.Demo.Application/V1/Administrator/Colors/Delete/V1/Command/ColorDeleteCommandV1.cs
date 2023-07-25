namespace Spoon.Demo.Application.V1.Administrator.Colors.Delete.V1.Command;

/// <summary>
///     Class ProductDeleteQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class ColorDeleteCommandV1 : MediatorBaseCommand, IHandleableRequest<ColorDeleteCommandV1,
    ColorDeleteCommandV1Handler,
    Either<ColorDeleteCommandV1Result>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ColorDeleteCommandV1" /> class.
    /// </summary>
    public ColorDeleteCommandV1()
        : base(typeof(ColorDeleteCommandV1))
    {
    }

    /// <summary>
    ///     Gets or sets the product identifier.
    /// </summary>
    /// <value>The product identifier.</value>
    public required Guid ColorId { get; set; }
}