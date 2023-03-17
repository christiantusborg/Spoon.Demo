namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Administration;

using Application.Administration.RemoveUserEmail;
using Contracts;
using EitherCore.Extensions;
using Extensions;
using Mediator.PipelineBehaviors.Permission;
using Mediator.PipelineBehaviors.Validation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
/// </summary>
public static class AdministrationRemoveUserEmailEndpoint
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapAdministrationRemoveUserEmail(this IEndpointRouteBuilder app)
    {
        app.MapPut(ApiAdministrationEndpoints.RemoveUserEmail.Endpoint,
                async ([FromRoute] Guid userId, [FromBody] AdministrationRemoveUserEmailRequest request, ISender sender, CancellationToken cancellationToken) =>
                {
                    var command = request.MapToCommand();
                    var commandResult = await sender.Send(command, cancellationToken);

                    var result = commandResult.ToNoContent();
                    return result;
                })
            .WithName(nameof(ApiAdministrationEndpoints.RemoveUserEmail))
            .Produces(204)
            .Produces<PermissionFailed<AdministrationRemoveUserEmailRequest>>(403)
            .Produces<Validationfailures>(406)
            .WithMetadata(new SwaggerOperationAttribute(ApiAdministrationEndpoints.RemoveUserEmail.Summary, ApiAdministrationEndpoints.RemoveUserEmail.Description));

        return app;
    }

    private static AdministrationRemoveUserEmailCommand MapToCommand(this AdministrationRemoveUserEmailRequest request)
    {
        var command = new AdministrationRemoveUserEmailCommand
        {
            UserId = request.UserId,
            EmailId = request.EmailId,
        };

        return command;
    }
}