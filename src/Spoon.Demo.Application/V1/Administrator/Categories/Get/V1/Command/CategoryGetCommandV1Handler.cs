namespace Spoon.Demo.Application.V1.Administrator.Categories.Get.V1.Command;

using Domain.Entities;
using Domain.Repositories;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class CategoryGetCommandV1Handler : IRequestHandler<CategoryGetCommandV1, Either<CategoryGetCommandV1Result>>
{
    private readonly ICategoryRepository _repository;

    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    public CategoryGetCommandV1Handler(IApplicationRepository repository)
    {
        this._repository = repository.Categories;
    }

    /// <summary>
    ///     Handles the specified request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="cancellationToken">
    ///     The cancellation token that can be used by other objects or threads to receive notice
    ///     of cancellation.
    /// </param>
    /// <returns>Task&lt;Either&lt;ProductCreateQueryResult&gt;&gt;.</returns>
    public async Task<Either<CategoryGetCommandV1Result>> Handle(
        CategoryGetCommandV1 request,
        CancellationToken cancellationToken)
    {
        var getSpecification = new DefaultGetSpecification<Category>(request.CategoryId);
        var existing = await this._repository.GetAsync(getSpecification, cancellationToken);

        if (existing == null)
            return EitherHelper<CategoryGetCommandV1Result>.EntityNotFound(typeof(CategoryGetCommandV1));

        await this._repository.SaveChangesAsync(cancellationToken);

        var result = new CategoryGetCommandV1Result
        {
            CategoryId = existing.CategoryId,
            Name = existing.Name,
            Description = existing.Description,
            Discount = existing.Discount,
            ProfitMargin = existing.ProfitMargin,
            CreatedAt = existing.CreatedAt,
            ModifiedAt = existing.ModifiedAt,
            DeletedAt = existing.DeletedAt,
        };

        return new Either<CategoryGetCommandV1Result>(result);
    }
}