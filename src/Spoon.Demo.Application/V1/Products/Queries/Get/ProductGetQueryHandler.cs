namespace Spoon.Demo.Application.V1.Products.Queries.Get
{
    using Domain.Entities;
    using Domain.Repositories;
    using Mapster;
    using MediatR;
    using NuGet.Core.Application;
    using NuGet.EitherCore;
    using NuGet.EitherCore.Helpers;

    /// <summary>
    ///     Class ProductGetQueryHandler. This class cannot be inherited.
    /// </summary>
    public sealed class ProductGetQueryHandler : IRequestHandler<ProductGetQuery, Either<ProductGetQueryResult>>
    {
        private readonly IReadOnlyRepository _readOnlyRepository;

        /// <summary>
        /// </summary>
        /// <param name="readOnlyRepository"></param>
        public ProductGetQueryHandler(IReadOnlyRepository readOnlyRepository)
        {
            this._readOnlyRepository = readOnlyRepository;
        }

        /// <summary>
        ///     Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">
        ///     The cancellation token that can be used by other objects or threads to receive notice
        ///     of cancellation.
        /// </param>
        /// <returns>Task&lt;Either&lt;ProductGetQueryResult&gt;&gt;.</returns>
        public async Task<Either<ProductGetQueryResult>> Handle(ProductGetQuery request, CancellationToken cancellationToken)
        {
            var product = await this._readOnlyRepository.Products.GetAsync(new DefaultGetSpecification<Product>(request.ProductId), cancellationToken);

            if (product is null)
            {
                return EitherHelper<ProductGetQueryResult>.EntityNotFound(typeof(ProductGetQuery));
            }

            var result = product.Adapt<ProductGetQueryResult>();

            return new Either<ProductGetQueryResult>(result);
        }
    }
}