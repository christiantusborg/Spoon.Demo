﻿namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Role.Get;

using Application.Commands.Roles.Get;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
/// </summary>
public class RoleGetEndpoint //: IEndpointMarker
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapGet(ApiRoleEndpoints.DeleteSoft.Endpoint, Get)
            .WithName(ApiRoleEndpoints.DeleteSoft.Name)
            .Produces(204)
            .Produces<Validationfailures>(406)
            .WithMetadata(new SwaggerOperationAttribute(ApiRoleEndpoints.DeleteSoft.Summary, ApiRoleEndpoints.DeleteSoft.Description));

        return app;
    }

    private static RoleGetCommand MapToCommand(Guid roleId)
    {
        var command = new RoleGetCommand
        {
            RoleId = roleId,
        };
        return command;
    }

    private static async Task<IResult> Get(Guid ruleId, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(ruleId);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}