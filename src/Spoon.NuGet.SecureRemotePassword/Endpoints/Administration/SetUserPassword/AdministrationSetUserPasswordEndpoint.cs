﻿namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Administration;

using System.Net;
using Application.Administration.SetUserPassword;
using Core.Presentation;
using EitherCore.Extensions;
using Extensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;
using Spoon.NuGet.Mediator.PipelineBehaviors.Validation;
using Spoon.NuGet.SecureRemotePassword.Contracts;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
/// </summary>
public class AdministrationSetUserPasswordEndpoint  : IEndpointMarker
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapPut(ApiAdministrationEndpoints.SetUserPassword.Endpoint, SetUserPassword)
            .WithName(ApiAdministrationEndpoints.SetUserPassword.Name)
            .Produces(204)
            .Produces<PermissionFailed<AdministrationSetUserPasswordResult>>(403)
            .Produces<Validationfailures>(406)
            .WithMetadata(new SwaggerOperationAttribute(ApiAdministrationEndpoints.SetUserPassword.Summary, ApiAdministrationEndpoints.SetUserPassword.Description));

        return app;
    }
    private static AdministrationSetUserPasswordCommand MapToCommand(AdministrationSetUserPasswordRequest request)
    {
        var command = new AdministrationSetUserPasswordCommand
        {
            UserId = request.UserId,
            Salt = request.Salt,
            Verifier = request.Verifier,
        };

        return command;
    }
    
    private static async Task<IResult> SetUserPassword([FromRoute] Guid userId,[FromBody] AdministrationSetUserPasswordRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(request);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }     

}