namespace Spoon.Demo.Presentation.Api.Endpoints.V1.Products;

using Contracts.Products.Requests;
using Contracts.Products.Results;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.AspNetCore.Routing;
using Spoon.Demo.Application.V1.Products.Commands.Create;
using Spoon.NuGet.EitherCore.Extensions;
using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;
using Spoon.NuGet.Mediator.PipelineBehaviors.Validation;
using Swashbuckle.AspNetCore.Annotations;

/// <summary>
/// 
/// </summary>
public static class UpdateProductEndpoint
{
    /// <summary>
    /// 
    /// </summary>
    public const string Name = "UpdateProduct";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapUpdateProduct(this IEndpointRouteBuilder app)
    {
        app.MapPut(ApiEndpoints.Products.Update, async (Guid productId, [FromBody] ProductUpdateRequest request, IOutputCacheStore outputCacheStore, ISender sender, CancellationToken cancellationToken) =>
            {
                var command = request.Adapt<ProductCreateCommand>();
                command.ProductId = productId;
                
                var commandResult = await sender.Send(command, cancellationToken);
                var contentResult = commandResult.ToResult(typeof(ProductUpdateResult));
                
                await outputCacheStore.EvictByTagAsync(ApiEndpoints.Products.Cache.EvictByTag, cancellationToken);
                return contentResult;
            })
            .WithName(Name)
            .Produces<ProductUpdateResult>(StatusCodes.Status200OK)
            .Produces<PermissionFailed<ProductUpdateResult>>(403)
            .Produces<Validationfailures>(406)
            .WithApiVersionSet(ApiVersioning.VersionSet!)
            .HasApiVersion(1.0)
            .WithMetadata(new SwaggerOperationAttribute(ApiEndpoints.Products.SwaggerOperation.UpdateSummary, ApiEndpoints.Products.SwaggerOperation.UpdateDescription));

        return app;
    }
}