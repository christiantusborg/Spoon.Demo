namespace Spoon.Demo.Application.V1.Administrator.Colors.Update.Endpoint;

using Categories.Update.Command;
using Command;
using Create.V1.Command;

//public static class GetChallengeAuthentication
/// <summary>
///     Represents an endpoint for creating a new Color.
/// </summary>
public class ColorUpdateEndpointV1 : BaseEndpoint, IEndpointMarker
{
    //v1/Color/
    /// <summary>
    ///     Maps the endpoint to the specified route builder.
    /// </summary>
    /// <param name="app">The route builder to map the endpoint to.</param>
    /// <returns>The route builder with the endpoint mapped.</returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapPut(this.GetEndpointName(), EndpointHandler)
            .WithName(this.GetType().Name)
            .Produces(BaseHttpStatusCodes.Status204NoContent)
            .Produces<PermissionFailed<ColorUpdateCommandV1>>(BaseHttpStatusCodes.Status401Unauthorized)
            .Produces<Validationfailures>(BaseHttpStatusCodes.Status406NotAcceptable)
            .Produces(BaseHttpStatusCodes.Status404NotFound)
            .Produces(BaseHttpStatusCodes.Status499TokenRequired)
            .Produces(BaseHttpStatusCodes.Status498InvalidToken)
            .WithMetadata(new SwaggerOperationAttribute(this.GetEndpointSummary(), this.GetEndpointDescription()));
        return app;
    }

    /// <summary>
    /// Handles the HTTP POST request for creating a new Color.
    /// </summary>
    /// <param name="ColorId"></param>
    /// <param name="request">The <see cref="ColorUpdateEndpointV1Request"/> containing the information for the new Color.</param>
    /// <param name="sender">The <see cref="ISender"/> instance used to send the command to the mediator.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation if needed.</param>
    /// <returns>An <see cref="IResult"/> instance representing the HTTP response.</returns>
    private static async Task<IResult> EndpointHandler(Guid ColorId, [FromBody] ColorUpdateEndpointV1Request request, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(request, ColorId);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }

    /// <summary>
    /// Maps a <see cref="ColorUpdateEndpointV1Request"/> to a <see cref="ColorCreateCommandV1"/> instance.
    /// </summary>
    /// <param name="request">The <see cref="ColorUpdateEndpointV1Request"/> to map.</param>
    /// <param name="ColorId"></param>
    /// <returns>A <see cref="ColorCreateCommandV1"/> instance.</returns>
    private static ColorUpdateCommandV1 MapToCommand(ColorUpdateEndpointV1Request request, Guid ColorId)
    {
        var command = new ColorUpdateCommandV1
        {
            ColorId = ColorId,
            Name = request.Name,
            Description = request.Description,
        };
        return command;
    }
}