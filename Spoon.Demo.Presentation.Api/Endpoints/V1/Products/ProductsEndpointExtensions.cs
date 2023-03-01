namespace Spoon.Demo.Presentation.Api.Endpoints.V1.Products;

using Microsoft.AspNetCore.Routing;

/// <summary>
/// 
/// </summary>
public static class ProductsEndpointExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapProductsEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGetProduct();
        app.MapCreateProduct();
        app.MapGetAllProducts();
        app.MapUpdateProduct();
        app.MapDeleteProduct();
        
        return app;
    }
}