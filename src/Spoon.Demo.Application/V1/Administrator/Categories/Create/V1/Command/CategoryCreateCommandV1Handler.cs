namespace Spoon.Demo.Application.V1.Administrator.Categories.Create.V1.Command;

using Domain.Entities;
using Domain.Repositories;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class CategoryCreateCommandV1Handler : IRequestHandler<CategoryCreateCommandV1, Either<CategoryCreateCommandV1Result>>
{
    private readonly ICategoryRepository _repository;
    private readonly IMockbleGuidGenerator _mockbleGuidGenerator;
    private readonly IMockbleDateTime _mockbleDateTime;

    /// <summary>
    ///     Initializes a new instance of the <see cref="CategoryCreateCommandV1Handler" /> class.
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="mockbleGuidGenerator"></param>
    /// <param name="mockbleDateTime"></param>
    public CategoryCreateCommandV1Handler(IApplicationRepository repository, IMockbleGuidGenerator mockbleGuidGenerator, IMockbleDateTime mockbleDateTime)
    {
        this._repository = repository.Categories;
        this._mockbleGuidGenerator = mockbleGuidGenerator;
        this._mockbleDateTime = mockbleDateTime;
    }

    /// <summary>
    ///     Handles the specified request.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Either<CategoryCreateCommandV1Result>> Handle(
        CategoryCreateCommandV1 request,
        CancellationToken cancellationToken)
    {
        var getByNameSpecification = new GetByNameSpecification<Category>(request.Name);
            
        var existing = await this._repository.GetAsync(getByNameSpecification, cancellationToken);

        if (existing is not null)
            return EitherHelper<CategoryCreateCommandV1Result>.EntityAlreadyExists(typeof(CategoryCreateCommandV1));

        var newGuid = this._mockbleGuidGenerator.NewId();

        var next = new Category
        {
            Name = request.Name,
            Discount = request.Discount,
            CategoryId = newGuid,
            Description = request.Description,
            ProfitMargin = request.ProfitMargin,
            CreatedAt = this._mockbleDateTime.UtcNow,
            ModifiedAt = this._mockbleDateTime.UtcNow,
            DeletedAt = null,
        };

        this._repository.Add(next);

        await this._repository.SaveChangesAsync(cancellationToken);

        var result = new CategoryCreateCommandV1Result
        {
            CategoryId = newGuid,
        };

        return new Either<CategoryCreateCommandV1Result>(result);
    }
}