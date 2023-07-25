// ReSharper disable ClassNeverInstantiated.Global

namespace Spoon.Demo.Application.V1.Administrator.Colors.GetAll.V1.Command;

using Domain.Entities;
using Domain.Repositories;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class ColorGetAllCommandV1Handler : IRequestHandler<ColorGetAllCommandV1, Either<BaseSearchCommandResult<ColorGetAllCommandV1Result>>>
{
    private readonly IColorRepository _repository;

    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    public ColorGetAllCommandV1Handler(IApplicationRepository repository)
    {
        this._repository = repository.Colors;
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
    public async Task<Either<BaseSearchCommandResult<ColorGetAllCommandV1Result>>> Handle(
        ColorGetAllCommandV1 request,
        CancellationToken cancellationToken)
    {
        var getAllSpecification = new DefaultSearchSpecification<Color>(request.Filters, request.SortField, request.Skip, request.Take, request.IncludeDeleted);
        var existing = await this._repository.SearchAsync(getAllSpecification, cancellationToken);

        if (existing.Count == 0)
            return new Either<BaseSearchCommandResult<ColorGetAllCommandV1Result>>(new BaseSearchCommandResult<ColorGetAllCommandV1Result>());

        var total = await this._repository.CountAsync(getAllSpecification, cancellationToken);

        var result = new BaseSearchCommandResult<ColorGetAllCommandV1Result>
        {
            Items = existing.Select(x => new ColorGetAllCommandV1Result
            {
                ColorId = x.ColorId,
                Name = x.Name,
                Description = x.Description,
                CreatedAt = x.CreatedAt,
                ModifiedAt = x.ModifiedAt,
                DeletedAt = x.DeletedAt,
            }).ToList(),
            Total = total,
        };

        return new Either<BaseSearchCommandResult<ColorGetAllCommandV1Result>>(result);
    }
}