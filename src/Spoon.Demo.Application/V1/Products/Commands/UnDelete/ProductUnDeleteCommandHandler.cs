namespace Spoon.Demo.Application.V1.Products.Commands.UnDelete;

using Domain.Entities;
using Domain.Repositories;
using MediatR;
using NuGet.Core.Application;
using NuGet.EitherCore;
using NuGet.EitherCore.Helpers;

/// <summary>
/// Class ProductDeleteQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class ProductUnDeleteCommandHandler : IRequestHandler<ProductUnDeleteCommand, Either<ProductUnDeleteCommandResult>>
{
    private readonly IWriteRepository _writeRepository;

    /// <summary>
    /// </summary>
    /// <param name="writeRepository"></param>
    public ProductUnDeleteCommandHandler(IWriteRepository writeRepository)
    {
        this._writeRepository = writeRepository;
    }

    /// <summary>
    /// Handles the specified request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="cancellationToken">The cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <returns>Task&lt;Either&lt;ProductDeleteQueryResult&gt;&gt;.</returns>
    public async Task<Either<ProductUnDeleteCommandResult>> Handle(
        ProductUnDeleteCommand request,
        CancellationToken cancellationToken)
    {
        var product = await this._writeRepository.Products.GetAsync(new DefaultGetSpecification<Product>(request.ProductId), cancellationToken);
        
        if (product is null)
        {
            return EitherHelper<ProductUnDeleteCommandResult>.EntityNotFound(typeof(ProductUnDeleteCommand));
        }

        product.DeletedAt = null;

        await this._writeRepository.SaveChanges(cancellationToken);
        
        var result = new ProductUnDeleteCommandResult
        {
            ProductId = product.ProductId,
        };
        
        return new Either<ProductUnDeleteCommandResult>(result);
    }
}
