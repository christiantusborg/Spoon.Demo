namespace Spoon.Demo.Presentation.Api.Endpoints.V1.Products.Extensions;

using Microsoft.AspNetCore.Routing;

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