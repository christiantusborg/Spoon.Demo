namespace Spoon.Demo.Application.V1.Administrator.Categories.Delete.V1.Command;

using Domain.Entities;
using Domain.Repositories;

/// <summary>
///     Class ProductDeleteQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class CategoryDeleteCommandV1Handler : IRequestHandler<CategoryDeleteCommandV1, Either<CategoryDeleteCommandV1Result>>
{
    private readonly ICategoryRepository _repository;
    private readonly IMockbleDateTime _mockbleDateTime;


    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="mockbleDateTime"></param>
    public CategoryDeleteCommandV1Handler(IApplicationRepository repository, IMockbleDateTime mockbleDateTime)
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
    /// <returns>Task&lt;Either&lt;ProductDeleteQueryResult&gt;&gt;.</returns>
    public async Task<Either<CategoryDeleteCommandV1Result>> Handle(
        CategoryDeleteCommandV1 request,
        CancellationToken cancellationToken)
    {
        var getSpecification = new DefaultGetSpecification<Category>(request.CategoryId);
        
        var existing = await this._repository.GetAsync(getSpecification, cancellationToken);

        if (existing is null)
        {
            return EitherHelper<CategoryDeleteCommandV1Result>.EntityNotFound(typeof(CategoryDeleteCommandV1));
        }

        existing.DeletedAt = this._mockbleDateTime.UtcNow;

        await this._repository.SaveChangesAsync(cancellationToken);

        return new Either<CategoryDeleteCommandV1Result>(new CategoryDeleteCommandV1Result());
    }
}