namespace Spoon.Demo.Application.V1.Administrator.Categories.GetAll.V1.Command;

using Spoon.NuGet.Core.Application;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
/// </summary>
public sealed class CategoryGetAllCommandV1 : MediatorBaseCommandSearch, IHandleableRequest<CategoryGetAllCommandV1,
    CategoryGetAllCommandV1Handler, Either<BaseSearchCommandResult<CategoryGetAllCommandV1Result>>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="CategoryGetAllCommandV1" /> class.
    /// </summary>
    public CategoryGetAllCommandV1()
        : base(typeof(CategoryGetAllCommandV1))
    {
    }
}