namespace Spoon.Demo.Application.V1.Administrator.Colors.Delete.V1.Command;

using Domain.Entities;
using Domain.Repositories;

/// <summary>
///     Class ProductDeleteQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class ColorDeleteCommandV1Handler : IRequestHandler<ColorDeleteCommandV1, Either<ColorDeleteCommandV1Result>>
{
    private readonly IColorRepository _repository;
    private readonly IMockbleDateTime _mockbleDateTime;


    /// <summary>
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="mockbleDateTime"></param>
    public ColorDeleteCommandV1Handler(IApplicationRepository repository, IMockbleDateTime mockbleDateTime)
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
    /// <returns>Task&lt;Either&lt;ProductDeleteQueryResult&gt;&gt;.</returns>
    public async Task<Either<ColorDeleteCommandV1Result>> Handle(
        ColorDeleteCommandV1 request,
        CancellationToken cancellationToken)
    {
        var getSpecification = new DefaultGetSpecification<Color>(request.ColorId);
        
        var exiting = await this._repository.GetAsync(getSpecification, cancellationToken);

        if (exiting is null)
        {
            return EitherHelper<ColorDeleteCommandV1Result>.EntityNotFound(typeof(ColorDeleteCommandV1));
        }

        exiting.DeletedAt = this._mockbleDateTime.UtcNow;

        await this._repository.SaveChangesAsync(cancellationToken);

        return new Either<ColorDeleteCommandV1Result>(new ColorDeleteCommandV1Result());
    }
}