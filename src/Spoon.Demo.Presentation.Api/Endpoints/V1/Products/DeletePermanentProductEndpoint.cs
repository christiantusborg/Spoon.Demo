﻿namespace Spoon.Demo.Presentation.Api.Endpoints.V1.Products;

using Contracts.Products.Results;
using Mappings;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;

/// <summary>
/// </summary>
public static class DeletePermanentProductEndpoint
{
    /// <summary>
    /// </summary>
    public const string Name = "DeletePermanentProduct";

    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapDeletePermanentProduct(this IEndpointRouteBuilder app)
    {
        app.MapDelete(ApiEndpoints.Products.DeletePermanent.Endpoint, async (Guid productId, IOutputCacheStore outputCacheStore, ISender sender, CancellationToken cancellationToken) =>
            {
                var command = MapProduct.ToDeleteCommand(productId);
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
            .WithMetadata(new SwaggerOperationAttribute(ApiEndpoints.Products.DeletePermanent.Summary, ApiEndpoints.Products.DeletePermanent.Description));

        return app;
    }
}