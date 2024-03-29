namespace Spoon.Demo.Application.V1.Administrator.Colors.Update.Command;

using Domain.Entities;
using Domain.Repositories;

/// <summary>
///     Class ProductUpdateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class ColorUpdateCommandV1Handler : IRequestHandler<ColorUpdateCommandV1, Either<ColorUpdateCommandV1Result>>
{
    private readonly IColorRepository _repository;
    private readonly IMockbleDateTime _mockbleDateTime;

    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="mockbleDateTime"></param>
    public ColorUpdateCommandV1Handler(IApplicationRepository repository, IMockbleDateTime mockbleDateTime)
    {
        this._repository = repository.Colors;
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
    public async Task<Either<ColorUpdateCommandV1Result>> Handle(
        ColorUpdateCommandV1 request,
        CancellationToken cancellationToken)
    {
        var getSpecification = new DefaultGetSpecification<Color>(request.ColorId);
        
        var existing = await this._repository.GetAsync(getSpecification, cancellationToken);

        if (existing is null)
            return EitherHelper<ColorUpdateCommandV1Result>.EntityNotFound(typeof(ColorUpdateCommandV1));

        existing.Name = request.Name ?? existing.Name;
        existing.Description = request.Description ?? existing.Description;
        existing.ModifiedAt = this._mockbleDateTime.UtcNow;

        await this._repository.SaveChangesAsync(cancellationToken);

        return new Either<ColorUpdateCommandV1Result>(new ColorUpdateCommandV1Result());
    }
}