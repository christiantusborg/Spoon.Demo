namespace Spoon.Demo.Application.V1.Administrator.CustomerTypes.Delete.V1.Endpoint;

using Command;

//public static class GetChallengeAuthentication
/// <summary>
///     Represents an endpoint for creating a new Delete.
/// </summary>
public class CustomerTypeDeleteEndpointV1 : BaseEndpoint, IEndpointMarker
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
            .Produces<PermissionFailed<CustomerTypeDeleteCommandV1>>(BaseHttpStatusCodes.Status401Unauthorized)
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
    /// <param name="customerTypeId"></param>
    /// <param name="sender">The <see cref="ISender" /> instance used to send the command to the mediator.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation if needed.</param>
    /// <returns>An <see cref="IResult" /> instance representing the HTTP response.</returns>
    private static async Task<IResult> EndpointHandler(Guid customerTypeId, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(customerTypeId);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }

    /// <summary>
    ///     Maps CustomerTypeId to a <see cref="CustomerTypeDeleteCommandV1" /> instance.
    /// </summary>
    /// <param name="customerTypeId"></param>
    /// <returns>A <see cref="CustomerTypeDeleteCommandV1" /> instance.</returns>
    private static CustomerTypeDeleteCommandV1 MapToCommand(Guid customerTypeId)
    {
        var command = new CustomerTypeDeleteCommandV1
        {
            CustomerTypeId = customerTypeId,
        };
        return command;
    }
}