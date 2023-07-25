namespace Spoon.Demo.Application.V1.Administrator.CustomerTypes.Create.V1.Endpoint;

using Command;

//public static class GetChallengeAuthentication
/// <summary>
///     Represents an endpoint for creating a new CustomerType.
/// </summary>
public class CustomerTypeCreateEndpointV1 : BaseEndpoint, IEndpointMarker
{
    //v1/CustomerType/
    /// <summary>
    ///     Maps the endpoint to the specified route builder.
    /// </summary>
    /// <param name="app">The route builder to map the endpoint to.</param>
    /// <returns>The route builder with the endpoint mapped.</returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapPost(this.GetEndpointName(), EndpointHandler)
            .WithName(this.GetType().Name)
            .Produces<CustomerTypeCreateEndpointV1Response>(BaseHttpStatusCodes.Status201Created)
            .Produces<PermissionFailed<CustomerTypeCreateCommandV1>>(BaseHttpStatusCodes.Status401Unauthorized)
            .Produces<Validationfailures>(BaseHttpStatusCodes.Status406NotAcceptable)
            .Produces(BaseHttpStatusCodes.Status404NotFound)
            .Produces(BaseHttpStatusCodes.Status499TokenRequired)
            .Produces(BaseHttpStatusCodes.Status498InvalidToken)
            .WithMetadata(new SwaggerOperationAttribute(this.GetEndpointSummary(), this.GetEndpointDescription()))
            .WithMetadata(new SwaggerResponseExampleAttribute(BaseHttpStatusCodes.Status201Created, typeof(CustomerTypeCreateEndpointV1RequestExample)))
            .WithMetadata(new SwaggerRequestExampleAttribute(typeof(CustomerTypeCreateEndpointV1Request), typeof(CustomerTypeCreateEndpointV1RequestExample)));
        return app;
    }

    /// <summary>
    /// Handles the HTTP POST request for creating a new CustomerType.
    /// </summary>
    /// <param name="request">The <see cref="CustomerTypeCreateEndpointV1Request"/> containing the information for the new CustomerType.</param>
    /// <param name="sender">The <see cref="ISender"/> instance used to send the command to the mediator.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation if needed.</param>
    /// <returns>An <see cref="IResult"/> instance representing the HTTP response.</returns>
    private static async Task<IResult> EndpointHandler([FromBody] CustomerTypeCreateEndpointV1Request request, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(request);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToResult(typeof(CustomerTypeCreateEndpointV1Response));
        return result;
    }

    /// <summary>
    /// Maps a <see cref="CustomerTypeCreateEndpointV1Request"/> to a <see cref="CustomerTypeCreateCommandV1"/> instance.
    /// </summary>
    /// <param name="request">The <see cref="CustomerTypeCreateEndpointV1Request"/> to map.</param>
    /// <returns>A <see cref="CustomerTypeCreateCommandV1"/> instance.</returns>
    private static CustomerTypeCreateCommandV1 MapToCommand(CustomerTypeCreateEndpointV1Request request)
    {
        var command = new CustomerTypeCreateCommandV1
        {
            Name = request.Name,
            Description = request.Description,
            
        };
        return command;
    }
}