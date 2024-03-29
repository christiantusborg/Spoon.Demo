﻿namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Administration.RemoveUserEmail;

using Application.Commands.Administration.RemoveUserEmail;
using Contracts;
using Core.Presentation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
/// </summary>
public class AdministrationRemoveUserEmailEndpoint : IEndpointMarker
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapPut(ApiAdministrationEndpoints.RemoveUserEmail.Endpoint, RemoveUserEmail)
            .WithName(ApiAdministrationEndpoints.RemoveUserEmail.Name)
            .Produces(204)
            .Produces<PermissionFailed<AdministrationRemoveUserEmailRequest>>(403)
            .Produces<Validationfailures>(406)
            .WithMetadata(new SwaggerOperationAttribute(ApiAdministrationEndpoints.RemoveUserEmail.Summary, ApiAdministrationEndpoints.RemoveUserEmail.Description));

        return app;
    }

    private static AdministrationRemoveUserEmailCommand MapToCommand(AdministrationRemoveUserEmailRequest request)
    {
        var command = new AdministrationRemoveUserEmailCommand
        {
            UserId = request.UserId,
            EmailId = request.EmailId,
        };

        return command;
    }

    private static async Task<IResult> RemoveUserEmail([FromRoute] Guid userId, [FromBody] AdministrationRemoveUserEmailRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(request);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}