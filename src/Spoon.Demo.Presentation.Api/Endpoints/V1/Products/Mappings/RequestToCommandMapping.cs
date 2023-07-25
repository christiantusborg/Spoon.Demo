namespace Spoon.Demo.Presentation.Api.Endpoints.V1.Products.Mappings;

using Application.V1.Administrator.Products.Commands.Create;
using Application.V1.Administrator.Products.Commands.Delete;
using Application.V1.Administrator.Products.Commands.Update;
using Contracts.Products.Requests;
using Mapster;

/// <summary>
/// </summary>
public static class MapProduct
{
    /// <inheritdoc cref="ApiEndpoints" />
    public static ProductGetQuery MapTo(this ProductGetRequest request)
    {
        var command = request.Adapt<ProductGetQuery>();
        return command;
    }

    /// <inheritdoc cref="ApiEndpoints" />
    public static ProductUpdateCommand MapTo(this ProductUpdateRequest request, Guid productId)
    {
        var command = request.Adapt<ProductUpdateCommand>();
        command.ProductId = productId;
        return command;
    }

    /// <inheritdoc cref="ApiEndpoints" />
    public static ProductCreateCommand MapTo(this ProductCreateRequest request)
    {
        // var command = request.Adapt<ProductCreateCommand>();
        var command = new ProductCreateCommand
        {
            ProductId = request.ProductId,
        };
        return command;
    }

    /// <inheritdoc cref="ApiEndpoints" />
    public static ProductSearchQuery MapTo(this ProductSearchRequest request)
    {
        //TODO Work with real api endpoint
        var command = request.Adapt<ProductSearchQuery>();
        return command;
    }

    /// <inheritdoc cref="ApiEndpoints" />
    public static ProductDeletePermanentCommand ToDeletePermanentCommand(Guid productId)
    {
        var command = new ProductDeletePermanentCommand
        {
            ProductId = productId,
        };
        return command;
    }

    /// <inheritdoc cref="ApiEndpoints" />
    public static ProductDeleteCommand ToDeleteCommand(Guid productId)
    {
        var command = new ProductDeleteCommand
        {
            ProductId = productId,
        };
        return command;
    }
}