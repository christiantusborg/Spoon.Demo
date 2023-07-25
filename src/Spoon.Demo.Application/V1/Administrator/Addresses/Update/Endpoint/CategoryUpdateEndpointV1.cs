namespace Spoon.Demo.Application.V1.Administrator.Addresses.Update.Endpoint;

using Command;
using Create.V1.Command;

//public static class GetChallengeAuthentication
/// <summary>
///     Represents an endpoint for creating a new Address.
/// </summary>
public class AddressUpdateEndpointV1 : BaseEndpoint, IEndpointMarker
{
    //v1/Address/
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
            .Produces<PermissionFailed<AddressCreateCommandV1>>(BaseHttpStatusCodes.Status401Unauthorized)
            .Produces<Validationfailures>(BaseHttpStatusCodes.Status406NotAcceptable)
            .Produces(BaseHttpStatusCodes.Status404NotFound)
            .Produces(BaseHttpStatusCodes.Status499TokenRequired)
            .Produces(BaseHttpStatusCodes.Status498InvalidToken)
            .WithMetadata(new SwaggerOperationAttribute(this.GetEndpointSummary(), this.GetEndpointDescription()));
        return app;
    }

    /// <summary>
    /// Handles the HTTP POST request for creating a new Address.
    /// </summary>
    /// <param name="addressId"></param>
    /// <param name="request">The <see cref="AddressUpdateEndpointV1Request"/> containing the information for the new Address.</param>
    /// <param name="sender">The <see cref="ISender"/> instance used to send the command to the mediator.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation if needed.</param>
    /// <returns>An <see cref="IResult"/> instance representing the HTTP response.</returns>
    private static async Task<IResult> EndpointHandler(Guid addressId, [FromBody] AddressUpdateEndpointV1Request request, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(request, addressId);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }

    /// <summary>
    /// Maps a <see cref="AddressUpdateEndpointV1Request"/> to a <see cref="AddressCreateCommandV1"/> instance.
    /// </summary>
    /// <param name="request">The <see cref="AddressUpdateEndpointV1Request"/> to map.</param>
    /// <param name="addressId"></param>
    /// <returns>A <see cref="AddressCreateCommandV1"/> instance.</returns>
    private static AddressUpdateCommandV1 MapToCommand(AddressUpdateEndpointV1Request request, Guid addressId)
    {
        var command = new AddressUpdateCommandV1
        {
            AddressId = addressId,
            City = request.City,
            Country = request.Country,
            CustomerId = request.CustomerId,
            Zip = request.Zip,
            AddressOne = request.AddressOne,
            AddressTwo = request.AddressTwo,
            AddressTypeId = request.AddressTypeId,
        };
        return command;
    }
}