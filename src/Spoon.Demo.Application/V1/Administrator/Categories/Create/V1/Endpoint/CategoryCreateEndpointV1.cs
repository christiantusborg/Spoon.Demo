﻿namespace Spoon.Demo.Application.V1.Administrator.Categories.Create.V1.Endpoint;

using Command;

//public static class GetChallengeAuthentication
/// <summary>
///     Represents an endpoint for creating a new category.
/// </summary>
public class CategoryCreateEndpointV1 : BaseEndpoint, IEndpointMarker
{
    //v1/category/
    /// <summary>
    ///     Maps the endpoint to the specified route builder.
    /// </summary>
    /// <param name="app">The route builder to map the endpoint to.</param>
    /// <returns>The route builder with the endpoint mapped.</returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapPost(this.GetEndpointName(), EndpointHandler)
            .WithName(this.GetType().Name)
            .Produces<CategoryCreateEndpointV1Response>(BaseHttpStatusCodes.Status201Created)
            .Produces<PermissionFailed<CategoryCreateCommandV1>>(BaseHttpStatusCodes.Status401Unauthorized)
            .Produces<Validationfailures>(BaseHttpStatusCodes.Status406NotAcceptable)
            .Produces(BaseHttpStatusCodes.Status404NotFound)
            .Produces(BaseHttpStatusCodes.Status499TokenRequired)
            .Produces(BaseHttpStatusCodes.Status498InvalidToken)
            .WithMetadata(new SwaggerOperationAttribute(this.GetEndpointSummary(), this.GetEndpointDescription()))
            .WithMetadata(new SwaggerResponseExampleAttribute(BaseHttpStatusCodes.Status201Created, typeof(CategoryCreateEndpointV1RequestExample)))
            .WithMetadata(new SwaggerRequestExampleAttribute(typeof(CategoryCreateEndpointV1Request), typeof(CategoryCreateEndpointV1RequestExample)));
        return app;
    }

    /// <summary>
    /// Handles the HTTP POST request for creating a new category.
    /// </summary>
    /// <param name="request">The <see cref="CategoryCreateEndpointV1Request"/> containing the information for the new category.</param>
    /// <param name="sender">The <see cref="ISender"/> instance used to send the command to the mediator.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation if needed.</param>
    /// <returns>An <see cref="IResult"/> instance representing the HTTP response.</returns>
    private static async Task<IResult> EndpointHandler([FromBody] CategoryCreateEndpointV1Request request, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(request);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToResult(typeof(CategoryCreateEndpointV1Response));
        return result;
    }

    /// <summary>
    /// Maps a <see cref="CategoryCreateEndpointV1Request"/> to a <see cref="CategoryCreateCommandV1"/> instance.
    /// </summary>
    /// <param name="request">The <see cref="CategoryCreateEndpointV1Request"/> to map.</param>
    /// <returns>A <see cref="CategoryCreateCommandV1"/> instance.</returns>
    private static CategoryCreateCommandV1 MapToCommand(CategoryCreateEndpointV1Request request)
    {
        var command = new CategoryCreateCommandV1
        {
            Name = request.Name,
            Description = request.Description,
            Discount = request.Discount,
            ProfitMargin = request.ProfitMargin,
        };
        return command;
    }
}