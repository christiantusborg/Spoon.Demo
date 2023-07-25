namespace Spoon.Demo.Application.V1.Administrator.Categories.GetAll.V1.Endpoint;

using Command;
using NuGet.Core.Domain;
using Spoon.Demo.Application.V1.Administrator.Categories.Create.V1.Command;

//public static class GetChallengeAuthentication
/// <summary>
///     Represents an endpoint for creating a new category.
/// </summary>
public class CategoryGetAllEndpointV1 : BaseEndpoint, IEndpointMarker
{
    /// <summary>
    ///     Maps the endpoint to the specified route builder.
    /// </summary>
    /// <param name="app">The route builder to map the endpoint to.</param>
    /// <returns>The route builder with the endpoint mapped.</returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapGet(this.GetEndpointName(), EndpointHandler)
            .WithName(this.GetType().Name)
            .Produces<CategoryGetAllEndpointV1Response>(BaseHttpStatusCodes.Status201Created)
            .Produces<PermissionFailed<CategoryCreateCommandV1>>(BaseHttpStatusCodes.Status401Unauthorized)
            .Produces<Validationfailures>(BaseHttpStatusCodes.Status406NotAcceptable)
            .Produces(BaseHttpStatusCodes.Status404NotFound)
            .Produces(BaseHttpStatusCodes.Status499TokenRequired)
            .Produces(BaseHttpStatusCodes.Status498InvalidToken)
            .WithMetadata(new SwaggerOperationAttribute(this.GetEndpointSummary(), this.GetEndpointDescription()))
            .WithMetadata(new SwaggerResponseExampleAttribute(BaseHttpStatusCodes.Status201Created, typeof(CategoryGetAllEndpointV1RequestExample)))
            .WithMetadata(new SwaggerRequestExampleAttribute(typeof(CategoryGetAllEndpointV1Request), typeof(CategoryGetAllEndpointV1RequestExample)));
        return app;
    }

    /// <summary>
    /// Handles the HTTP POST request for creating a new category.
    /// </summary>
    /// <param name="request">The <see cref="CategoryGetAllEndpointV1Request"/> containing the information for the new category.</param>
    /// <param name="sender">The <see cref="ISender"/> instance used to send the command to the mediator.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation if needed.</param>
    /// <returns>An <see cref="IResult"/> instance representing the HTTP response.</returns>
    private static async Task<IResult> EndpointHandler([FromQuery] CategoryGetAllEndpointV1Request request, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(request);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToResult(typeof(CategoryGetAllEndpointV1Response));
        return result;
    }

    /// <summary>
    /// Maps a <see cref="CategoryGetAllEndpointV1Request"/> to a <see cref="CategoryCreateCommandV1"/> instance.
    /// </summary>
    /// <param name="request">The <see cref="CategoryGetAllEndpointV1Request"/> to map.</param>
    /// <returns>A <see cref="CategoryCreateCommandV1"/> instance.</returns>
    private static CategoryGetAllCommandV1 MapToCommand(CategoryGetAllEndpointV1Request request)
    {
        var command = new CategoryGetAllCommandV1
        {
            Filters = request.Filters ?? new List<Filter>(),
            Page = request.Page,
            PageLength = request.PageLength,
            SortField = request.SortField ?? new List<Sorting>(),
            IncludeDeleted = request.IncludeDeletedSoft,
        };
        return command;
    }
}