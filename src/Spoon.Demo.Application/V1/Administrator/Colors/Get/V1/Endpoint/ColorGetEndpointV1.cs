namespace Spoon.Demo.Application.V1.Administrator.Colors.Get.V1.Endpoint;

using Command;
using Create.V1.Command;

//public static class GetChallengeAuthentication
/// <summary>
///     Represents an endpoint for creating a new Color.
/// </summary>
public class ColorGetEndpointV1 : BaseEndpoint, IEndpointMarker
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
            .Produces<ColorGetEndpointV1Response>(BaseHttpStatusCodes.Status201Created)
            .Produces<PermissionFailed<ColorGetCommandV1>>(BaseHttpStatusCodes.Status401Unauthorized)
            .Produces<Validationfailures>(BaseHttpStatusCodes.Status406NotAcceptable)
            .Produces(BaseHttpStatusCodes.Status404NotFound)
            .Produces(BaseHttpStatusCodes.Status499TokenRequired)
            .Produces(BaseHttpStatusCodes.Status498InvalidToken)
            .WithMetadata(new SwaggerOperationAttribute(this.GetEndpointSummary(), this.GetEndpointDescription()));
        return app;
    }

    /// <summary>
    ///     Handles the HTTP POST request for creating a new Color.
    /// </summary>
    /// <param name="ColorId"></param>
    /// <param name="sender">The <see cref="ISender" /> instance used to send the command to the mediator.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation if needed.</param>
    /// <returns>An <see cref="IResult" /> instance representing the HTTP response.</returns>
    private static async Task<IResult> EndpointHandler(Guid ColorId, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(ColorId);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToResult(typeof(ColorGetEndpointV1Response));
        return result;
    }

    /// <summary>
    ///     Maps ColorId to a <see cref="ColorCreateCommandV1" /> instance.
    /// </summary>
    /// <param name="ColorId"></param>
    /// <returns>A <see cref="ColorCreateCommandV1" /> instance.</returns>
    private static ColorGetCommandV1 MapToCommand(Guid ColorId)
    {
        var command = new ColorGetCommandV1
        {
            ColorId = ColorId,
        };
        return command;
    }
}