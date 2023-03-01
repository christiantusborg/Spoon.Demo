namespace Spoon.Demo.Presentation.Api.Endpoints.V1.Products;

using Contracts.Products.Requests;
using Contracts.Products.Results;
using Mappings;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Spoon.NuGet.EitherCore.Extensions;
using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;
using Spoon.NuGet.Mediator.PipelineBehaviors.Validation;
using Swashbuckle.AspNetCore.Annotations;

/// <summary>
/// 
/// </summary>
public static class CreateProductEndpoint
{
    /// <summary>
    /// 
    /// </summary>
    public const string Name = "CreateProduct";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapCreateProduct(this IEndpointRouteBuilder app)
    {
        app.MapPost(ApiEndpoints.Products.Create,  async ([AsParameters] ProductGetRequest request, ISender sender, CancellationToken cancellationToken) =>
            {
                var command = request.MapTo();

                var commandResult = await sender.Send(command, cancellationToken);
                var contentResult = commandResult.ToResult(typeof(ProductGetResult));

                return contentResult;
            })
            .WithName(Name)
            .Produces<ProductGetResult>()
            .Produces<Validationfailures>(406)
            .Produces<PermissionFailed<ProductGetResult>>(403)
            .WithApiVersionSet(ApiVersioning.VersionSet!)
            .HasApiVersion(1.0)
            .WithMetadata(new SwaggerOperationAttribute("Get by ProductId", "Get by ProductId"));
        
        return app;
    }
}