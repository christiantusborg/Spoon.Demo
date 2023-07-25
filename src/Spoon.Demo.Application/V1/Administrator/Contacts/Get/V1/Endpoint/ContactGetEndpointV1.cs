namespace Spoon.Demo.Application.V1.Administrator.Contacts.Get.V1.Endpoint;

using Command;
using Create.V1.Command;

//public static class GetChallengeAuthentication
/// <summary>
///     Represents an endpoint for creating a new Contact.
/// </summary>
public class ContactGetEndpointV1 : BaseEndpoint, IEndpointMarker
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
            .Produces<ContactGetEndpointV1Response>(BaseHttpStatusCodes.Status201Created)
            .Produces<PermissionFailed<ContactGetCommandV1>>(BaseHttpStatusCodes.Status401Unauthorized)
            .Produces<Validationfailures>(BaseHttpStatusCodes.Status406NotAcceptable)
            .Produces(BaseHttpStatusCodes.Status404NotFound)
            .Produces(BaseHttpStatusCodes.Status499TokenRequired)
            .Produces(BaseHttpStatusCodes.Status498InvalidToken)
            .WithMetadata(new SwaggerOperationAttribute(this.GetEndpointSummary(), this.GetEndpointDescription()));
        return app;
    }

    /// <summary>
    ///     Handles the HTTP POST request for creating a new Contact.
    /// </summary>
    /// <param name="contactId"></param>
    /// <param name="sender">The <see cref="ISender" /> instance used to send the command to the mediator.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation if needed.</param>
    /// <returns>An <see cref="IResult" /> instance representing the HTTP response.</returns>
    private static async Task<IResult> EndpointHandler(Guid contactId, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(contactId);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToResult(typeof(ContactGetEndpointV1Response));
        return result;
    }

    /// <summary>
    ///     Maps ContactId to a <see cref="ContactCreateCommandV1" /> instance.
    /// </summary>
    /// <param name="contactId"></param>
    /// <returns>A <see cref="ContactCreateCommandV1" /> instance.</returns>
    private static ContactGetCommandV1 MapToCommand(Guid contactId)
    {
        var command = new ContactGetCommandV1
        {
            ContactId = contactId,
        };
        return command;
    }
}