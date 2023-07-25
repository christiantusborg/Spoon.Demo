namespace Spoon.Demo.Application.V1.Administrator.Categories.UnDelete.V1.Command;

using Domain.Entities;
using Domain.Repositories;

/// <summary>
///     Class ProductDeleteQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class CategoryUnDeleteCommandV1Handler : IRequestHandler<CategoryUnDeleteCommandV1, Either<CategoryUnDeleteCommandV1Result>>
{
    private readonly ICategoryRepository _repository;

    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    public CategoryUnDeleteCommandV1Handler(IApplicationRepository repository)
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
    /// <returns>Task&lt;Either&lt;ProductDeleteQueryResult&gt;&gt;.</returns>
    public async Task<Either<CategoryUnDeleteCommandV1Result>> Handle(
        CategoryUnDeleteCommandV1 request,
        CancellationToken cancellationToken)
    {
        var getSpecification = new DefaultGetSpecification<Category>(request.CategoryId);
        
        var existing = await this._repository.GetAsync(getSpecification, cancellationToken);

        if (existing is null)
        {
            return EitherHelper<CategoryUnDeleteCommandV1Result>.EntityNotFound(typeof(CategoryUnDeleteCommandV1));
        }

        existing.DeletedAt = null;

        await this._repository.SaveChangesAsync(cancellationToken);

        return new Either<CategoryUnDeleteCommandV1Result>(new CategoryUnDeleteCommandV1Result());
    }
}