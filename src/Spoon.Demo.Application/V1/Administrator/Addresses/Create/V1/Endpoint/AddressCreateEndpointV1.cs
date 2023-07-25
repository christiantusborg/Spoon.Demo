namespace Spoon.Demo.Application.V1.Administrator.Addresses.Create.V1.Endpoint;

using Command;

//public static class GetChallengeAuthentication
/// <summary>
///     Represents an endpoint for creating a new Address.
/// </summary>
public class AddressCreateEndpointV1 : BaseEndpoint, IEndpointMarker
{
    //v1/Address/
    /// <summary>
    ///     Maps the endpoint to the specified route builder.
    /// </summary>
    /// <param name="app">The route builder to map the endpoint to.</param>
    /// <returns>The route builder with the endpoint mapped.</returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapPost(this.GetEndpointName(), EndpointHandler)
            .WithName(this.GetType().Name)
            .Produces<AddressCreateEndpointV1Response>(BaseHttpStatusCodes.Status201Created)
            .Produces<PermissionFailed<AddressCreateCommandV1>>(BaseHttpStatusCodes.Status401Unauthorized)
            .Produces<Validationfailures>(BaseHttpStatusCodes.Status406NotAcceptable)
            .Produces(BaseHttpStatusCodes.Status404NotFound)
            .Produces(BaseHttpStatusCodes.Status499TokenRequired)
            .Produces(BaseHttpStatusCodes.Status498InvalidToken)
            .WithMetadata(new SwaggerOperationAttribute(this.GetEndpointSummary(), this.GetEndpointDescription()))
            .WithMetadata(new SwaggerResponseExampleAttribute(BaseHttpStatusCodes.Status201Created, typeof(AddressCreateEndpointV1RequestExample)))
            .WithMetadata(new SwaggerRequestExampleAttribute(typeof(AddressCreateEndpointV1Request), typeof(AddressCreateEndpointV1RequestExample)));
        return app;
    }

    /// <summary>
    /// Handles the HTTP POST request for creating a new Address.
    /// </summary>
    /// <param name="request">The <see cref="AddressCreateEndpointV1Request"/> containing the information for the new Address.</param>
    /// <param name="sender">The <see cref="ISender"/> instance used to send the command to the mediator.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation if needed.</param>
    /// <returns>An <see cref="IResult"/> instance representing the HTTP response.</returns>
    private static async Task<IResult> EndpointHandler([FromBody] AddressCreateEndpointV1Request request, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(request);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToResult(typeof(AddressCreateEndpointV1Response));
        
        return result;
    }

    /// <summary>
    /// Maps a <see cref="AddressCreateEndpointV1Request"/> to a <see cref="AddressCreateCommandV1"/> instance.
    /// </summary>
    /// <param name="request">The <see cref="AddressCreateEndpointV1Request"/> to map.</param>
    /// <returns>A <see cref="AddressCreateCommandV1"/> instance.</returns>
    private static AddressCreateCommandV1 MapToCommand(AddressCreateEndpointV1Request request)
    {
        var command = new AddressCreateCommandV1
        {
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