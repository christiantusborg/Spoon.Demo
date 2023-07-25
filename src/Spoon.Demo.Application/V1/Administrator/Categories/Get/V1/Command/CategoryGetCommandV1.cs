namespace Spoon.Demo.Application.V1.Administrator.Categories.Get.V1.Command;

using Spoon.NuGet.Core.Application;

/// <summary>
///     Class ProductCreateQuery. This class cannot be inherited.
///     Implements the <see cref="MediatorBaseCommand" />.
/// </summary>
/// <seealso cref="MediatorBaseCommand" />
public sealed class CategoryGetCommandV1 : MediatorBaseCommand, IHandleableRequest<CategoryGetCommandV1,
    CategoryGetCommandV1Handler, Either<CategoryGetCommandV1Result>>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="CategoryGetCommandV1" /> class.
    /// </summary>
    public CategoryGetCommandV1()
        : base(typeof(CategoryGetCommandV1))
    {
    }

    /// <inheritdoc cref="MediatorBaseCommand" />
    public required Guid CategoryId { get; set; }

}