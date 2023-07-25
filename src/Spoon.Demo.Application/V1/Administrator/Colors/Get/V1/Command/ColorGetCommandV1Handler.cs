namespace Spoon.Demo.Application.V1.Administrator.Colors.Get.V1.Command;

using Domain.Entities;
using Domain.Repositories;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class ColorGetCommandV1Handler : IRequestHandler<ColorGetCommandV1, Either<ColorGetCommandV1Result>>
{
    private readonly IColorRepository _repository;

    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    public ColorGetCommandV1Handler(IApplicationRepository repository)
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
    public async Task<Either<ColorGetCommandV1Result>> Handle(
        ColorGetCommandV1 request,
        CancellationToken cancellationToken)
    {
        var getSpecification = new DefaultGetSpecification<Color>(request.ColorId);
        
        var existing = await this._repository.GetAsync(getSpecification, cancellationToken);

        if (existing == null)
            return EitherHelper<ColorGetCommandV1Result>.EntityNotFound(typeof(ColorGetCommandV1));

        await this._repository.SaveChangesAsync(cancellationToken);

        var result = new ColorGetCommandV1Result
        {
            ColorId = existing.ColorId,
            Name = existing.Name,
            Description = existing.Description,
            CreatedAt = existing.CreatedAt,
            ModifiedAt = existing.ModifiedAt,
            DeletedAt = existing.DeletedAt,
        };

        return new Either<ColorGetCommandV1Result>(result);
    }
}