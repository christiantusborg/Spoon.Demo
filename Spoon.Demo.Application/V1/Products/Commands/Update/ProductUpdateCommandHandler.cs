namespace Spoon.Demo.Application.V1.Products.Commands.Update;

using Domain.Entities;
using Domain.Repositories;
using Mapster;
using MediatR;
using NuGet.Core.Application;
using NuGet.EitherCore;
using NuGet.EitherCore.Helpers;

/// <summary>
/// Class ProductUpdateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Either<ProductUpdateCommandResult>>
{
    private readonly IWriteRepository _writeRepository;

    /// <summary>
    /// </summary>
    /// <param name="writeRepository"></param>
    public ProductUpdateCommandHandler(IWriteRepository writeRepository)
    {
        this._writeRepository = writeRepository;
    }

    /// <summary>
    /// Handles the specified request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Task&lt;Either&lt;ProductUpdateQueryResult&gt;&gt;.</returns>
    public async Task<Either<ProductUpdateCommandResult>> Handle(
        ProductUpdateCommand request,
        CancellationToken cancellationToken)
    {
        var product = await this._writeRepository.Products.Get(new DefaultGetSpecification<Product>(request.ProductId), cancellationToken);

        if (product is null)
            return EitherHelper<ProductUpdateCommandResult>.EntityNotFound(typeof(ProductUpdateCommand));

        product = request.Adapt(product, TypeAdapterConfig<ProductUpdateCommand, Product>
            .NewConfig()
            .IgnoreNullValues(true).Config);
        
        await this._writeRepository.SaveChanges(cancellationToken);

        var result = product.Adapt<ProductUpdateCommandResult>(TypeAdapterConfig<Product, ProductUpdateCommandResult>.NewConfig()
                .Map(dest => dest.Name, src => src.Name ?? string.Empty).Config);
        
        return new Either<ProductUpdateCommandResult>(result);
    }
}
