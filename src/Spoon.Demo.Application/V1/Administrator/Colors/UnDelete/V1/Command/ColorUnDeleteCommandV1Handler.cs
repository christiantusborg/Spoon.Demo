namespace Spoon.Demo.Application.V1.Administrator.Colors.UnDelete.V1.Command;

using Domain.Entities;
using Domain.Repositories;

/// <summary>
///     Class ProductDeleteQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class ColorUnDeleteCommandV1Handler : IRequestHandler<ColorUnDeleteCommandV1, Either<ColorUnDeleteCommandV1Result>>
{
    private readonly IColorRepository _repository;

    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    public ColorUnDeleteCommandV1Handler(IApplicationRepository repository)
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
    /// <returns>Task&lt;Either&lt;ProductDeleteQueryResult&gt;&gt;.</returns>
    public async Task<Either<ColorUnDeleteCommandV1Result>> Handle(
        ColorUnDeleteCommandV1 request,
        CancellationToken cancellationToken)
    {
        
        var getSpecification = new DefaultGetSpecification<Color>(request.ColorId);
        
        var existing = await this._repository.GetAsync(getSpecification, cancellationToken);

        if (existing is null)
        {
            return EitherHelper<ColorUnDeleteCommandV1Result>.EntityNotFound(typeof(ColorUnDeleteCommandV1));
        }

        existing.DeletedAt = null;

        await this._repository.SaveChangesAsync(cancellationToken);

        return new Either<ColorUnDeleteCommandV1Result>(new ColorUnDeleteCommandV1Result());
    }
}