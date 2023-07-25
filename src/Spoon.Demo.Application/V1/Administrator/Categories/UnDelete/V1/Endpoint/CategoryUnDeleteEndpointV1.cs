namespace Spoon.Demo.Application.V1.Administrator.Categories.UnDelete.V1.Endpoint;

using Command;
using Spoon.Demo.Application.V1.Administrator.Categories.Create.V1.Command;

//public static class GetChallengeAuthentication
/// <summary>
///     Represents an endpoint for creating a new category.
/// </summary>
public class CategoryUnDeleteEndpointV1 : BaseEndpoint, IEndpointMarker
{
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
            .Produces<PermissionFailed<CategoryCreateCommandV1>>(BaseHttpStatusCodes.Status401Unauthorized)
            .Produces<Validationfailures>(BaseHttpStatusCodes.Status406NotAcceptable)
            .Produces(BaseHttpStatusCodes.Status404NotFound)
            .Produces(BaseHttpStatusCodes.Status499TokenRequired)
            .Produces(BaseHttpStatusCodes.Status498InvalidToken)
            .WithMetadata(new SwaggerOperationAttribute(this.GetEndpointSummary(), this.GetEndpointDescription()));
        return app;
    }

    /// <summary>
    /// Handles the HTTP POST request for creating a new category.
    /// </summary>
    /// <param name="categoryId"></param>
    /// <param name="sender">The <see cref="ISender"/> instance used to send the command to the mediator.</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation if needed.</param>
    /// <returns>An <see cref="IResult"/> instance representing the HTTP response.</returns>
    private static async Task<IResult> EndpointHandler(Guid categoryId, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(categoryId);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }



    /// <summary>
    /// Maps categoryId to a <see cref="CategoryCreateCommandV1"/> instance.
    /// </summary>
    /// <returns>A <see cref="CategoryCreateCommandV1"/> instance.</returns>
    private static CategoryUnDeleteCommandV1 MapToCommand(Guid categoryId)
    {
        var command = new CategoryUnDeleteCommandV1
        {
            CategoryId = categoryId,
        };
        return command;
    }
}