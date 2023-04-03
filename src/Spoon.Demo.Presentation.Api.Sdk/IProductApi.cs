/*
namespace Spoon.Demo.Presentation.Api.Sdk;

using Contracts;
using Contracts.Products.Requests;
using Contracts.Products.Results;
using Refit;

[Headers("Authorization: Bearer")]
public interface IProductApi
{
    [Get(ApiEndpoints.Products.Get)]
    Task<ProductGetResult> GetProductAsync(string idOrSlug);

    [Get(ApiEndpoints.Products.GetAll)]
    Task<ProductSearchResult> GetMProductAsync(ProductSearchRequest request);
    
    [Post(ApiEndpoints.Products.Create)]
    Task<ProductCreateResult> CreateProductAsync(ProductCreateRequest request);
    
    [Put(ApiEndpoints.Products.Update)]
    Task<ProductUpdateResult> UpdateProductAsync(Guid id, ProductUpdateRequest request);
    
    [Delete(ApiEndpoints.Products.Delete)]
    Task DeleteProductAsync(Guid id);
    
    [Delete(ApiEndpoints.Products.DeletePermanent)]
    Task DeletePermanentProductAsync(Guid id);    
}
*/