namespace Spoon.Demo.Presentation.Api.Endpoints.V1.Products;

using Contracts;
using Contracts.Products.Results;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Annotations;

/// <summary>
/// </summary>
public static class GetAllProductEndpoint
{
    /// <summary>
    /// </summary>
    public const string Name = "GetAllProduct";

    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapGetAllProducts(this IEndpointRouteBuilder app)
    {
        app.MapGet(ApiEndpoints.Products.GetAll.Endpoint, async (int? page, int? pageLength, SearchRequest search, [FromServices] ISender sender) =>
            {
                var command = new ProductSearchQuery
                {
                    Filters = search.Filters,
                    Page = page ?? 1,
                    PageLength = pageLength ?? 10,
                }; //request.Adapt<ProductSearchQuery>();

                var commandResult = await sender.Send(command);
                // var contentResult = commandResult.ToXResult<ProductSearchQueryResult,ProductSearchResult>();
                var contentResult = commandResult.ToResult(typeof(ProductSearchQueryResult));

                return contentResult;
                // return Results.Ok();
            })
            .WithName(Name)
            .WithApiVersionSet(ApiVersioning.VersionSet!)
            .HasApiVersion(1.0)
            .Produces<ProductSearchResult>()
            .Produces<Validationfailures>(406)
            .CacheOutput(ApiEndpoints.Products.GetAll.Policy)
            .WithMetadata(new SwaggerOperationAttribute(ApiEndpoints.Products.GetAll.Summary, ApiEndpoints.Products.GetAll.Description));
        ;
        return app;
    }
}