namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Administration;

using Application.Administration.SetUserEmailAsPrimary;
using Contracts;
using Core.Presentation;
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
public class AdministrationSetUserEmailAsPrimaryEndpoint  : IEndpointMarker
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map( IEndpointRouteBuilder app)
    {
        app.MapPut(ApiAdministrationEndpoints.SetUserEmailAsPrimary.Endpoint,SetUserEmailAsPrimary)
            .WithName(ApiAdministrationEndpoints.SetUserEmailAsPrimary.Name)
            .Produces(204)
            .Produces<PermissionFailed<AdministrationSetUserEmailAsPrimaryResult>>(403)
            .Produces<Validationfailures>(406)
            .WithMetadata(new SwaggerOperationAttribute(ApiAdministrationEndpoints.SetUserEmailAsPrimary.Summary, ApiAdministrationEndpoints.SetUserEmailAsPrimary.Description));

        return app;
    }

    private static AdministrationSetUserEmailAsPrimaryCommand MapToCommand(AdministrationSetUserEmailAsPrimaryRequest request)
    {
        var command = new AdministrationSetUserEmailAsPrimaryCommand
        {
            UserId = request.UserId,
            EmailId = request.EmailId,
        };

        return command;
    }
    
    private static async Task<IResult> SetUserEmailAsPrimary([FromRoute] Guid userId, [FromBody] AdministrationSetUserEmailAsPrimaryRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(request);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    } 
}