namespace Spoon.Demo.Application.V1.Administrator.Contacts.Delete.V1.Endpoint;

using Command;

//public static class GetChallengeAuthentication
/// <summary>
///     Represents an endpoint for creating a new Delete.
/// </summary>
public class ContactDeleteEndpointV1 : BaseEndpoint, IEndpointMarker
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
            .Produces<PermissionFailed<ContactDeleteCommandV1>>(BaseHttpStatusCodes.Status401Unauthorized)
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
    /// <param name="contactId"></param>
    /// <param name="sender">The <see cref="ISender" /> instance used to send the command to the mediator.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation if needed.</param>
    /// <returns>An <see cref="IResult" /> instance representing the HTTP response.</returns>
    private static async Task<IResult> EndpointHandler(Guid contactId, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(contactId);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }

    /// <summary>
    ///   Maps ContactId to a <see cref="ContactDeleteCommandV1" /> instance.
    /// </summary>
    /// <param name="contactId"></param>
    /// <returns>A <see cref="ContactDeleteCommandV1" /> instance.</returns>
    private static ContactDeleteCommandV1 MapToCommand(Guid contactId)
    {
        var command = new ContactDeleteCommandV1
        {
            ContactId = contactId,
        };
        return command;
    }
}