namespace Spoon.Demo.Application.V1.Administrator.Colors.GetAll.V1.Command;

using Spoon.NuGet.Core.Application;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
/// </summary>
public sealed class ColorGetAllCommandV1 : MediatorBaseCommandSearch, IHandleableRequest<ColorGetAllCommandV1,
    ColorGetAllCommandV1Handler, Either<BaseSearchCommandResult<ColorGetAllCommandV1Result>>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ColorGetAllCommandV1" /> class.
    /// </summary>
    public ColorGetAllCommandV1()
        : base(typeof(ColorGetAllCommandV1))
    {
    }
}