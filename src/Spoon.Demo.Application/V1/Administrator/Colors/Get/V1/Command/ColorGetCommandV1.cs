namespace Spoon.Demo.Application.V1.Administrator.Colors.Get.V1.Command;

using Spoon.NuGet.Core.Application;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class ColorGetCommandV1 : MediatorBaseCommand, IHandleableRequest<ColorGetCommandV1,
    ColorGetCommandV1Handler, Either<ColorGetCommandV1Result>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ColorGetCommandV1" /> class.
    /// </summary>
    public ColorGetCommandV1()
        : base(typeof(ColorGetCommandV1))
    {
    }

    /// <inheritdoc cref="MediatorBaseCommand" />
    public required Guid ColorId { get; set; }

}