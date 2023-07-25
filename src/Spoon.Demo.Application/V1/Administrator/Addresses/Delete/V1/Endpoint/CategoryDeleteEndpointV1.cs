namespace Spoon.Demo.Application.V1.Administrator.Addresses.Delete.V1.Endpoint;

using Command;

//public static class GetChallengeAuthentication
/// <summary>
///     Represents an endpoint for creating a new Delete.
/// </summary>
public class AddressDeleteEndpointV1 : BaseEndpoint, IEndpointMarker
{
    /// <summary>
    ///     Maps the endpoint to the specified route builder.
    /// </summary>
    /// <param name="app">The route builder to map the endpoint to.</param>
    /// <returns>The route builder with the endpoint mapped.</returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapDelete(this.GetEndpointName(), EndpointHandler)
            .WithName(this.GetType().Name)
            .Produces(BaseHttpStatusCodes.Status204NoContent)
            .Produces<PermissionFailed<AddressDeleteCommandV1>>(BaseHttpStatusCodes.Status401Unauthorized)
            .Produces<Validationfailures>(BaseHttpStatusCodes.Status406NotAcceptable)
            .Produces(BaseHttpStatusCodes.Status404NotFound)
            .Produces(BaseHttpStatusCodes.Status499TokenRequired)
            .Produces(BaseHttpStatusCodes.Status498InvalidToken)
            .WithMetadata(new SwaggerOperationAttribute(this.GetEndpointSummary(), this.GetEndpointDescription()));
        return app;
    }

    /// <summary>
    ///     Handles the HTTP POST request for creating a new Delete.
    /// </summary>
    /// <param name="AddressId"></param>
    /// <param name="sender">The <see cref="ISender" /> instance used to send the command to the mediator.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation if needed.</param>
    /// <returns>An <see cref="IResult" /> instance representing the HTTP response.</returns>
    private static async Task<IResult> EndpointHandler(Guid AddressId, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(AddressId);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }

    /// <summary>
    ///   Maps AddressId to a <see cref="AddressDeleteCommandV1" /> instance.
    /// </summary>
    /// <param name="AddressId"></param>
    /// <returns>A <see cref="AddressDeleteCommandV1" /> instance.</returns>
    private static AddressDeleteCommandV1 MapToCommand(Guid AddressId)
    {
        var command = new AddressDeleteCommandV1
        {
            AddressId = AddressId,
        };
        return command;
    }
}