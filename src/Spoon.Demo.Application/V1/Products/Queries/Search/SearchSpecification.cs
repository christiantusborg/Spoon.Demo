namespace Spoon.Demo.Application.V1.Products.Queries.Search
{
    using Domain.Entities;
    using NuGet.Core.Domain;

    /// <inheritdoc />
    public class SearchSpecification : Specification<Product>
    {
        /// <inheritdoc />
        public SearchSpecification(List<Filter> filters, int skip, int take)
        {
            this.AddFilters(filters);

            this.AddInclude(x => x.Features);
            
            //this.AddInclude(x => x.Supplier);
            
            //this.AddInclude(x => x.Color);
            
            //this.AddInclude(x => x.Size);            
            
            this.AddSkip(skip);
            
            this.AddTake(take);
            
            this.AddOrderBy(x => x.Sku);
            
            
        }
    }
}