namespace Spoon.Demo.Application.V1.Administrator.Categories.Update.Command;

using Domain.Entities;
using Domain.Repositories;

/// <summary>
///     Class ProductUpdateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class CategoryUpdateCommandV1Handler : IRequestHandler<CategoryUpdateCommandV1, Either<CategoryUpdateCommandV1Result>>
{
    private readonly ICategoryRepository _repository;
    private readonly IMockbleDateTime _mockbleDateTime;

    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="mockbleDateTime"></param>
    public CategoryUpdateCommandV1Handler(IApplicationRepository repository, IMockbleDateTime mockbleDateTime)
    {
        this._repository = repository.Categories;
        this._mockbleDateTime = mockbleDateTime;
    }

    /// <summary>
    ///     Handles the specified request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="cancellationToken">
    ///     The cancellation token that can be used by other objects or threads to receive notice
    ///     of cancellation.
    /// </param>
    /// <returns>Task&lt;Either&lt;ProductUpdateQueryResult&gt;&gt;.</returns>
    public async Task<Either<CategoryUpdateCommandV1Result>> Handle(
        CategoryUpdateCommandV1 request,
        CancellationToken cancellationToken)
    {
        var getSpecification = new DefaultGetSpecification<Category>(request.CategoryId);
        
        var existing = await this._repository.GetAsync(getSpecification, cancellationToken);

        if (existing is null)
            return EitherHelper<CategoryUpdateCommandV1Result>.EntityNotFound(typeof(CategoryUpdateCommandV1));

        existing.Name = request.Name ?? existing.Name;
        existing.Description = request.Description ?? existing.Description;
        existing.ModifiedAt = this._mockbleDateTime.UtcNow;
        existing.Discount = request.Discount ?? existing.Discount;
        existing.ProfitMargin = request.ProfitMargin ?? existing.ProfitMargin;

        await this._repository.SaveChangesAsync(cancellationToken);

        return new Either<CategoryUpdateCommandV1Result>(new CategoryUpdateCommandV1Result());
    }
}