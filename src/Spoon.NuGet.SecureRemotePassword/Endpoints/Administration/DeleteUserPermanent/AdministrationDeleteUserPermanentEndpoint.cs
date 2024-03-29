﻿namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Administration.DeleteUserPermanent;

using System.Security.Claims;
using Application.Commands.Administration.DeleteUserPermanent;
using Contracts;
using Core.Presentation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;
using ClaimsPrincipalExtensions = Extensions.ClaimsPrincipalExtensions;

//public static class GetChallengeAuthentication
/// <summary>
/// </summary>
public class AdministrationDeleteUserPermanentEndpoint : IEndpointMarker
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapDelete(ApiAdministrationEndpoints.DeleteUserPermanent.Endpoint, DeleteUserPermanent)
            .WithName(ApiAdministrationEndpoints.DeleteUserPermanent.Name)
            .Produces(204)
            .Produces<Validationfailures>(406)
            .Produces<PermissionFailed<AdministrationDeleteUserPermanentResult>>(403)
            .WithMetadata(new SwaggerOperationAttribute(ApiAdministrationEndpoints.DeleteUserPermanent.Summary, ApiAdministrationEndpoints.DeleteUserPermanent.Description));

        return app;
    }

    private static AdministrationDeleteUserPermanentCommand MapToCommand(Guid userId, Guid currentUserId)
    {
        var command = new AdministrationDeleteUserPermanentCommand
        {
            UserId = userId,
            CurrentUserId = currentUserId,
        };

        return command;
    }

    private static async Task<IResult> DeleteUserPermanent([FromRoute] Guid userId, ClaimsPrincipal claimsPrincipal, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(userId, ClaimsPrincipalExtensions.GetUserId(claimsPrincipal));
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}