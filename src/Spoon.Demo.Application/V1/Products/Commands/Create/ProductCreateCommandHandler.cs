namespace Spoon.Demo.Application.V1.Products.Commands.Create;

using Domain.Entities;
using Domain.Repositories;
using Mapster;
using MediatR;
using NuGet.Core;
using NuGet.Core.EitherCore;

/// <summary>
///     Class ProductCreateQueryHandler. This class cannot be inherited.
/// </summary>
public sealed class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Either<ProductCreateCommandResult>>
{
    private readonly IRepositoryRepository _repository;
    private readonly IMockbleGuidGenerator _mockbleGuidGenerator;

    /// <summary>
    /// </summary>
    /// <param name="writeRepository"></param>
    /// <param name="mockbleGuidGenerator"></param>
    public ProductCreateCommandHandler(IRepositoryRepository writeRepository, IMockbleGuidGenerator mockbleGuidGenerator)
    {
        this._repository = writeRepository;
        this._mockbleGuidGenerator = mockbleGuidGenerator;
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
    public async Task<Either<ProductCreateCommandResult>> Handle(
        ProductCreateCommand request,
        CancellationToken cancellationToken)
    {
        var product = request.Adapt<Product>();
        product.ProductId = this._mockbleGuidGenerator.NewGuid();

        this._repository.Products.Add(product);

        await this._repository.SaveChanges(cancellationToken);

        var result = new ProductCreateCommandResult
        {
            ProductId = product.ProductId,
        };

        return new Either<ProductCreateCommandResult>(result);
    }
}