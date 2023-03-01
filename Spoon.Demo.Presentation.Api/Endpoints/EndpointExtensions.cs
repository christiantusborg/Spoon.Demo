namespace Spoon.Demo.Presentation.Api.Endpoints;

using Microsoft.AspNetCore.Routing;
using V1.Products;

/// <summary>
/// 
/// </summary>
public static class EndpointExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapProductsEndpoints();
        
        return app;
    }
}