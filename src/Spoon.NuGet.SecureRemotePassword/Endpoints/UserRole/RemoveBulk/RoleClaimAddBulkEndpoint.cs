﻿namespace Spoon.NuGet.SecureRemotePassword.Endpoints.UserRole.RemoveBulk;

using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Spoon.NuGet.EitherCore.Extensions;
using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;
using Spoon.NuGet.Mediator.PipelineBehaviors.Validation;
using Spoon.NuGet.SecureRemotePassword.Application.UserRole.RemoveBulk;
using Spoon.NuGet.SecureRemotePassword.Contracts;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
/// </summary>
public static class UserRoleRemoveBulkEndpoint
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapUserRoleRemoveBulk(this IEndpointRouteBuilder app)
    {
        app.MapPut(ApiUserRoleEndpoints.RemoveBulk.Endpoint,RemoveBulk)
            .WithName(ApiUserRoleEndpoints.RemoveBulk.Name)
            .Produces(201)
            .Produces<PermissionFailed<AdministrationRemoveUserEmailResult>>(403)
            .Produces<Validationfailures>(406)
            .WithMetadata(new SwaggerOperationAttribute(ApiUserRoleEndpoints.RemoveBulk.Summary, ApiUserRoleEndpoints.RemoveBulk.Description));

        return app;
    }

    private static UserRoleRemoveBulkCommand MapToCommand(this UserRoleRemoveBulkCommandRequest request, Guid userId)
    {
        var command = new UserRoleRemoveBulkCommand
        {
            UserId = userId,
            Claims = request.Claims,
        };

        return command;
    }

    private static async Task<IResult> RemoveBulk([FromRoute] Guid userId, [FromBody] UserRoleRemoveBulkCommandRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = request.MapToCommand(userId);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}