namespace Spoon.Demo.Application.V1.Administrator.CustomerTypes.Update.Endpoint;

using Command;
using Create.V1.Command;

//public static class GetChallengeAuthentication
/// <summary>
///     Represents an endpoint for creating a new CustomerType.
/// </summary>
public class CustomerTypeUpdateEndpointV1 : BaseEndpoint, IEndpointMarker
{
    //v1/CustomerType/
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
            .Produces<PermissionFailed<CustomerTypeUpdateCommandV1>>(BaseHttpStatusCodes.Status401Unauthorized)
            .Produces<Validationfailures>(BaseHttpStatusCodes.Status406NotAcceptable)
            .Produces(BaseHttpStatusCodes.Status404NotFound)
            .Produces(BaseHttpStatusCodes.Status499TokenRequired)
            .Produces(BaseHttpStatusCodes.Status498InvalidToken)
            .WithMetadata(new SwaggerOperationAttribute(this.GetEndpointSummary(), this.GetEndpointDescription()));
        return app;
    }

    /// <summary>
    /// Handles the HTTP POST request for creating a new CustomerType.
    /// </summary>
    /// <param name="customerTypeId"></param>
    /// <param name="request">The <see cref="CustomerTypeUpdateEndpointV1Request"/> containing the information for the new CustomerType.</param>
    /// <param name="sender">The <see cref="ISender"/> instance used to send the command to the mediator.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation if needed.</param>
    /// <returns>An <see cref="IResult"/> instance representing the HTTP response.</returns>
    private static async Task<IResult> EndpointHandler(Guid customerTypeId, [FromBody] CustomerTypeUpdateEndpointV1Request request, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(request, customerTypeId);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }

    /// <summary>
    /// Maps a <see cref="CustomerTypeUpdateEndpointV1Request"/> to a <see cref="CustomerTypeCreateCommandV1"/> instance.
    /// </summary>
    /// <param name="request">The <see cref="CustomerTypeUpdateEndpointV1Request"/> to map.</param>
    /// <param name="customerTypeId"></param>
    /// <returns>A <see cref="CustomerTypeCreateCommandV1"/> instance.</returns>
    private static CustomerTypeUpdateCommandV1 MapToCommand(CustomerTypeUpdateEndpointV1Request request, Guid customerTypeId)
    {
        var command = new CustomerTypeUpdateCommandV1
        {
            CustomerTypeId = customerTypeId,
            Name = request.Name,
            Description = request.Description,
        };
        return command;
    }
}