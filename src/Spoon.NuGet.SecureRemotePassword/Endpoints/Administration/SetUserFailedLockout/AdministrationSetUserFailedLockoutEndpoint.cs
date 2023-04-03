namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Administration.SetUserFailedLockout;

using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Spoon.NuGet.Core.Presentation;
using Spoon.NuGet.EitherCore.Extensions;
using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;
using Spoon.NuGet.Mediator.PipelineBehaviors.Validation;
using Spoon.NuGet.SecureRemotePassword.Application.Administration.SetUserFailedLockout;
using Spoon.NuGet.SecureRemotePassword.Contracts;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
/// </summary>
public class AdministrationSetUserFailedLockoutEndpoint  : IEndpointMarker
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
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