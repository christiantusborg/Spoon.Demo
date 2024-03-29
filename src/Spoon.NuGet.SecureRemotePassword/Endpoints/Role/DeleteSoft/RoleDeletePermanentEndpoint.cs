﻿namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Role.DeleteSoft;

using Application.Commands.Roles.DeleteSoft;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
/// </summary>
public class RoleDeleteSoftEndpoint //: IEndpointMarker
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapDelete(ApiRoleEndpoints.DeleteSoft.Endpoint, DeleteSoftUser)
            .WithName(ApiRoleEndpoints.DeleteSoft.Name)
            .Produces(204)
            .Produces<Validationfailures>(406)
            .WithMetadata(new SwaggerOperationAttribute(ApiRoleEndpoints.DeleteSoft.Summary, ApiRoleEndpoints.DeleteSoft.Description));

        return app;
    }

    private static RoleDeleteSoftCommand MapToCommand(Guid roleId)
    {
        var command = new RoleDeleteSoftCommand
        {
            RoleId = roleId,
        };
        return command;
    }

    private static async Task<IResult> DeleteSoftUser(Guid ruleId, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(ruleId);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}