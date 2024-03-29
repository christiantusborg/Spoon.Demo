﻿namespace Spoon.Demo.Presentation.Api.Endpoints.V1.Products;

using Contracts.Products.Requests;
using Contracts.Products.Results;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;

/// <summary>
/// </summary>
public static class DeleteProductEndpoint
{
    /// <summary>
    /// </summary>
    public const string Name = "DeleteProduct";

    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapDeleteProduct(this IEndpointRouteBuilder app)
    {
        app.MapDelete(ApiEndpoints.Products.Delete.Endpoint,
                async ([AsParameters] ProductDeleteRequest request, IOutputCacheStore outputCacheStore, ISender sender, CancellationToken cancellationToken) =>
                {
                    var command = request.Adapt<ProductDeletePermanentCommand>();
                    var commandResult = await sender.Send(command, cancellationToken);
                    var contentResult = commandResult.ToNoContent();

                    await outputCacheStore.EvictByTagAsync(ApiEndpoints.Products.Cache.EvictByTag, cancellationToken);
                    return contentResult;
                })
            .WithName(Name)
            .Produces<ProductDeleteResult>()
            .Produces<PermissionFailed<ProductDeleteResult>>(403)
            .Produces<Validationfailures>(406)
            .WithApiVersionSet(ApiVersioning.VersionSet!)
            .HasApiVersion(1.0)
            .WithMetadata(new SwaggerOperationAttribute(ApiEndpoints.Products.Delete.Summary, ApiEndpoints.Products.Delete.Description));


        return app;
    }
}