﻿namespace Spoon.Demo.Presentation.Api.Endpoints.V1.Products;

using Contracts.Products.Requests;
using Contracts.Products.Results;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Annotations;

/// <summary>
/// </summary>
public static class GetProductEndpoint
{
    /// <summary>
    /// </summary>
    public const string Name = "GetProduct";

    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapGetProduct(this IEndpointRouteBuilder app)
    {
        app.MapGet(ApiEndpoints.Products.Get.Endpoint, async ([AsParameters] ProductGetRequest request, ISender sender, CancellationToken cancellationToken) =>
            {
                var command = request.Adapt<ProductGetQuery>();

                var commandResult = await sender.Send(command, cancellationToken);
                var contentResult = commandResult.ToResult(typeof(ProductGetResult));

                return contentResult;
            })
            .WithName(Name)
            .WithTags(ApiEndpoints.Products.Cache.EvictByTag)
            .Produces<ProductGetResult>()
            .Produces<Validationfailures>(406)
            .Produces<PermissionFailed<ProductGetResult>>(403)
            .WithMetadata(new SwaggerOperationAttribute(ApiEndpoints.Products.Get.Summary, ApiEndpoints.Products.Get.Description))
            .CacheOutput(ApiEndpoints.Products.Get.Policy);
        return app;
    }
}