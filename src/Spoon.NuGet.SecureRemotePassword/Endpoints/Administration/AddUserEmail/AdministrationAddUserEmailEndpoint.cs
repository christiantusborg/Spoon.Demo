namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Administration.AddUserEmail;

using Core.Presentation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Spoon.NuGet.EitherCore.Extensions;
using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;
using Spoon.NuGet.Mediator.PipelineBehaviors.Validation;
using Spoon.NuGet.SecureRemotePassword.Application.Administration.AddUserEmail;
using Spoon.NuGet.SecureRemotePassword.Contracts;
using Swashbuckle.AspNetCore.Annotations;



//public static class GetChallengeAuthentication
/// <summary>
/// </summary>
public class AdministrationAddUserEmailEndpoint  : IEndpointMarker
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapPut(ApiAdministrationEndpoints.AddUserEmail.Endpoint,AddUserEmail)
            .WithName(ApiAdministrationEndpoints.AddUserEmail.Name)
            .Produces(201)
            .Produces<PermissionFailed<AdministrationAddUserEmailResult>>(403)
            .Produces<Validationfailures>(406)
            .WithMetadata(new SwaggerOperationAttribute(ApiAdministrationEndpoints.AddUserEmail.Summary, ApiAdministrationEndpoints.AddUserEmail.Description));

        return app;
    }

    private AdministrationAddUserEmailCommand MapToCommand(AdministrationAddUserEmailRequest request, Guid userId)
    {
        var command = new AdministrationAddUserEmailCommand
        {
            UserId = userId,
            Email = request.Email,
        };

        return command;
    }

    private async Task<IResult> AddUserEmail([FromRoute] Guid userId, [FromBody] AdministrationAddUserEmailRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(request,userId);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}
