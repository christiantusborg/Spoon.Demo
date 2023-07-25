// ReSharper disable ClassNeverInstantiated.Global

namespace Spoon.Demo.Application.V1.Administrator.Categories.GetAll.V1.Command;

using Domain.Entities;
using Domain.Repositories;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class CategoryGetAllCommandV1Handler : IRequestHandler<CategoryGetAllCommandV1, Either<BaseSearchCommandResult<CategoryGetAllCommandV1Result>>>
{
    private readonly ICategoryRepository _repository;

    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    public CategoryGetAllCommandV1Handler(IApplicationRepository repository)
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
    public async Task<Either<BaseSearchCommandResult<CategoryGetAllCommandV1Result>>> Handle(
        CategoryGetAllCommandV1 request,
        CancellationToken cancellationToken)
    {
        var getAllSpecification = new DefaultSearchSpecification<Category>(request.Filters, request.SortField, request.Skip, request.Take, request.IncludeDeleted);

        var existing = await this._repository.SearchAsync(getAllSpecification, cancellationToken);

        if (existing.Count == 0)
            return new Either<BaseSearchCommandResult<CategoryGetAllCommandV1Result>>(new BaseSearchCommandResult<CategoryGetAllCommandV1Result>());


        var total = await this._repository.CountAsync(getAllSpecification, cancellationToken);

        var result = new BaseSearchCommandResult<CategoryGetAllCommandV1Result>
        {
            Items = existing.Select(x => new CategoryGetAllCommandV1Result
            {
                CategoryId = x.CategoryId,
                Name = x.Name,
                Description = x.Description,
                Discount = x.Discount,
                ProfitMargin = x.ProfitMargin,
                CreatedAt = x.CreatedAt,
                ModifiedAt = x.ModifiedAt,
                DeletedAt = x.DeletedAt,
            }).ToList(),
            Total = total,
        };

        return new Either<BaseSearchCommandResult<CategoryGetAllCommandV1Result>>(result);
    }
}