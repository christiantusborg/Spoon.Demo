namespace Spoon.Demo.Application.V1.Products.Commands.DeletePermanent;

using Domain.Entities;
using Domain.Repositories;
using MediatR;
using NuGet.Core.Application;
using NuGet.Core.EitherCore;
using NuGet.Core.EitherCore.Helpers;

/// <summary>
///     Class ProductDeletePermanentQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class ProductDeletePermanentCommandHandler : IRequestHandler<ProductDeletePermanentCommand, Either<ProductDeletePermanentCommandResult>>
{
    private readonly IRepositoryRepository _writeRepository;

    /// <summary>
    /// </summary>
    /// <param name="writeRepository"></param>
    public ProductDeletePermanentCommandHandler(IRepositoryRepository writeRepository)
    {
        this._writeRepository = writeRepository;
    }

    /// <summary>
    ///     Handles the specified request.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <param name="cancellationToken">
    ///     The cancellation token that can be used by other objects or threads to receive notice
    ///     of cancellation.
    /// </param>
    /// <returns>Task&lt;Either&lt;ProductDeletePermanentQueryResult&gt;&gt;.</returns>
    public async Task<Either<ProductDeletePermanentCommandResult>> Handle(
        ProductDeletePermanentCommand request,
        CancellationToken cancellationToken)
    {
        var product = await this._writeRepository.Products.GetAsync(new DefaultGetSpecification<Product>(request.ProductId), cancellationToken);

        if (product is null)
        {
            return EitherHelper<ProductDeletePermanentCommandResult>.EntityNotFound(typeof(ProductDeletePermanentCommand));
        }

        this._writeRepository.Products.Remove(product);

        await this._writeRepository.SaveChanges(cancellationToken);

        var result = new ProductDeletePermanentCommandResult
        {
            ProductId = product.ProductId,
        };

        return new Either<ProductDeletePermanentCommandResult>(result);
    }
}