namespace Spoon.Demo.Application.V1.Administrator.Colors.Create.V1.Command;

using Domain.Entities;
using Domain.Repositories;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class ColorCreateCommandV1Handler : IRequestHandler<ColorCreateCommandV1, Either<ColorCreateCommandV1Result>>
{
    private readonly IColorRepository _repository;
    private readonly IMockbleGuidGenerator _mockbleGuidGenerator;
    private readonly IMockbleDateTime _mockbleDateTime;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ColorCreateCommandV1Handler" /> class.
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="mockbleGuidGenerator"></param>
    /// <param name="mockbleDateTime"></param>
    public ColorCreateCommandV1Handler(IApplicationRepository repository, IMockbleGuidGenerator mockbleGuidGenerator, IMockbleDateTime mockbleDateTime)
    {
        this._repository = repository.Colors;
        this._mockbleGuidGenerator = mockbleGuidGenerator;
        this._mockbleDateTime = mockbleDateTime;
    }

    /// <summary>
    ///     Handles the specified request.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Either<ColorCreateCommandV1Result>> Handle(
        ColorCreateCommandV1 request,
        CancellationToken cancellationToken)
    {
        var getByNameSpecification = new GetByNameSpecification<Color>(request.Name);
        
        var existing = await this._repository.GetAsync(getByNameSpecification, cancellationToken);

        if (existing is not null)
            return EitherHelper<ColorCreateCommandV1Result>.EntityAlreadyExists(typeof(ColorCreateCommandV1));

        var colorId = this._mockbleGuidGenerator.NewId();

        var next = new Color
        {
            Name = request.Name,
            Description = request.Description,
            ColorId = colorId,
            CreatedAt = this._mockbleDateTime.UtcNow,
            ModifiedAt = this._mockbleDateTime.UtcNow,
            DeletedAt = null,
        };

        this._repository.Add(next);

        await this._repository.SaveChangesAsync(cancellationToken);

        var result = new ColorCreateCommandV1Result
        {
            ColorId = colorId,
        };

        return new Either<ColorCreateCommandV1Result>(result);
    }
}