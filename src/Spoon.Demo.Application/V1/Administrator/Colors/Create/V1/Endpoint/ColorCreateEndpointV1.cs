namespace Spoon.Demo.Application.V1.Administrator.Colors.Create.V1.Endpoint;

using Command;

//public static class GetChallengeAuthentication
/// <summary>
///     Represents an endpoint for creating a new Color.
/// </summary>
public class ColorCreateEndpointV1 : BaseEndpoint, IEndpointMarker
{
    //v1/Color/
    /// <summary>
    ///     Maps the endpoint to the specified route builder.
    /// </summary>
    /// <param name="app">The route builder to map the endpoint to.</param>
    /// <returns>The route builder with the endpoint mapped.</returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapPost(this.GetEndpointName(), EndpointHandler)
            .WithName(this.GetType().Name)
            .Produces<ColorCreateEndpointV1Response>(BaseHttpStatusCodes.Status201Created)
            .Produces<PermissionFailed<ColorCreateCommandV1>>(BaseHttpStatusCodes.Status401Unauthorized)
            .Produces<Validationfailures>(BaseHttpStatusCodes.Status406NotAcceptable)
            .Produces(BaseHttpStatusCodes.Status404NotFound)
            .Produces(BaseHttpStatusCodes.Status499TokenRequired)
            .Produces(BaseHttpStatusCodes.Status498InvalidToken)
            .WithMetadata(new SwaggerOperationAttribute(this.GetEndpointSummary(), this.GetEndpointDescription()))
            .WithMetadata(new SwaggerResponseExampleAttribute(BaseHttpStatusCodes.Status201Created, typeof(ColorCreateEndpointV1RequestExample)))
            .WithMetadata(new SwaggerRequestExampleAttribute(typeof(ColorCreateEndpointV1Request), typeof(ColorCreateEndpointV1RequestExample)));
        return app;
    }

    /// <summary>
    /// Handles the HTTP POST request for creating a new Color.
    /// </summary>
    /// <param name="request">The <see cref="ColorCreateEndpointV1Request"/> containing the information for the new Color.</param>
    /// <param name="sender">The <see cref="ISender"/> instance used to send the command to the mediator.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation if needed.</param>
    /// <returns>An <see cref="IResult"/> instance representing the HTTP response.</returns>
    private static async Task<IResult> EndpointHandler([FromBody] ColorCreateEndpointV1Request request, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(request);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToResult(typeof(ColorCreateEndpointV1Response));
        return result;
    }

    /// <summary>
    /// Maps a <see cref="ColorCreateEndpointV1Request"/> to a <see cref="ColorCreateCommandV1"/> instance.
    /// </summary>
    /// <param name="request">The <see cref="ColorCreateEndpointV1Request"/> to map.</param>
    /// <returns>A <see cref="ColorCreateCommandV1"/> instance.</returns>
    private static ColorCreateCommandV1 MapToCommand(ColorCreateEndpointV1Request request)
    {
        var command = new ColorCreateCommandV1
        {
            Name = request.Name,
            Description = request.Description,
            Discount = request.Discount,
            ProfitMargin = request.ProfitMargin,
        };
        return command;
    }
}