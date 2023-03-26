namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Administration;

using Application.Administration.SetUserFailedLockout;
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
public static class AdministrationSetUserFailedLockoutEndpoint
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapAdministrationSetUserFailedLockout(this IEndpointRouteBuilder app)
    {
        app.MapGet(ApiAdministrationEndpoints.SetUserFailedLockout.Endpoint,SetUserFailedLockout)
            .WithName(ApiAdministrationEndpoints.SetUserFailedLockout.Name)
            .Produces(204)
            .Produces<PermissionFailed<AdministrationSetUserFailedLockoutResult>>(403)
            .Produces<Validationfailures>(406)
            .WithMetadata(new SwaggerOperationAttribute(ApiAdministrationEndpoints.SetUserFailedLockout.Summary, ApiAdministrationEndpoints.SetUserFailedLockout.Description));

        return app;
    }

    private static AdministrationSetUserFailedLockoutCommand MapToCommand(Guid userId, bool value)
    {
        var command = new AdministrationSetUserFailedLockoutCommand
        {
            UserId = userId,
            Value = value,
        };

        return command;
    }
    
    private static async Task<IResult> SetUserFailedLockout([FromRoute] Guid userId, [FromRoute] bool value, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(userId, value);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    } 
}