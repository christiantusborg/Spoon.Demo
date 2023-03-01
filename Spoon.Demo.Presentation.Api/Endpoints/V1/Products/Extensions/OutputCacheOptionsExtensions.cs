namespace Spoon.Demo.Presentation.Api.Endpoints.V1.Products.Extensions;

using Microsoft.AspNetCore.OutputCaching;

/// <summary>
/// 
/// </summary>
public static class ProductsOutputCacheOptionsExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="outputCacheOptions"></param>
    /// <returns></returns>
    public static OutputCacheOptions AddCacheOptionsProducts(this OutputCacheOptions outputCacheOptions)
    {
        outputCacheOptions.AddPolicy(ApiEndpoints.Products.Cache.PolicyGetAll, c => 
            c.Cache()
                .Expire(TimeSpan.FromMinutes(1))
                .SetVaryByQuery(new[] { "search", "page", "pageLength" })
                .Tag(ApiEndpoints.Products.Cache.EvictByTag));

        outputCacheOptions.AddPolicy(ApiEndpoints.Products.Cache.PolicyGet, c => 
            c.Cache()
                .Expire(TimeSpan.FromMinutes(1))
                .SetVaryByQuery(new[] { "productId" })
                .Tag(ApiEndpoints.Products.Cache.EvictByTag));        
        return outputCacheOptions;
    }   
}