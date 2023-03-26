namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Administration;

using Application.Administration.SetUserEmailAsPrimary;
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
public static class AdministrationSetUserEmailAsPrimaryEndpoint
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapAdministrationSetUserEmailAsPrimary(this IEndpointRouteBuilder app)
    {
        app.MapPut(ApiAdministrationEndpoints.SetUserEmailAsPrimary.Endpoint,SetUserEmailAsPrimary)
            .WithName(ApiAdministrationEndpoints.SetUserEmailAsPrimary.Name)
            .Produces(204)
            .Produces<PermissionFailed<AdministrationSetUserEmailAsPrimaryResult>>(403)
            .Produces<Validationfailures>(406)
            .WithMetadata(new SwaggerOperationAttribute(ApiAdministrationEndpoints.SetUserEmailAsPrimary.Summary, ApiAdministrationEndpoints.SetUserEmailAsPrimary.Description));

        return app;
    }

    private static AdministrationSetUserEmailAsPrimaryCommand MapToCommand(this AdministrationSetUserEmailAsPrimaryRequest request)
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
        var command = request.MapToCommand();
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    } 
}