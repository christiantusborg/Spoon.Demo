namespace Spoon.Demo.Application.V1.Products.Commands.Delete;

using Domain.Entities;
using Domain.Repositories;
using MediatR;
using NuGet.Core;
using NuGet.Core.Application;
using NuGet.EitherCore;
using NuGet.EitherCore.Helpers;

/// <summary>
/// Class ProductDeleteQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class ProductDeleteCommandHandler : IRequestHandler<ProductDeleteCommand, Either<ProductDeleteCommandResult>>
{
    private readonly IWriteRepository _writeRepository;
    private readonly IMockbleDateTime _mockbleDateTime;


    /// <summary>
    /// 
    /// </summary>
    /// <param name="writeRepository"></param>
    /// <param name="mockbleDateTime"></param>
    public ProductDeleteCommandHandler(IWriteRepository writeRepository, IMockbleDateTime mockbleDateTime)
    {
        this._writeRepository = writeRepository;
        this._mockbleDateTime = mockbleDateTime;
    }

    /// <summary>
    /// Handles the specified request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Task&lt;Either&lt;ProductDeleteQueryResult&gt;&gt;.</returns>
    public async Task<Either<ProductDeleteCommandResult>> Handle(
        ProductDeleteCommand request,
        CancellationToken cancellationToken)
    {
        var product = await this._writeRepository.Products.Get(new DefaultGetSpecification<Product>(request.ProductId), cancellationToken);
        
        if (product is null)
        {
            return EitherHelper<ProductDeleteCommandResult>.EntityNotFound(typeof(ProductDeleteCommand));
        }

        
        product.DeletedAt =  this._mockbleDateTime.UtcNow;

        await this._writeRepository.SaveChanges(cancellationToken);
        
        var result = new ProductDeleteCommandResult
        {
            ProductId = product.ProductId,
        };
        
        return new Either<ProductDeleteCommandResult>(result);
    }
}
