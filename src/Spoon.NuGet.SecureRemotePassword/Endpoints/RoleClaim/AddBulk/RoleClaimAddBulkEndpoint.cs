namespace Spoon.NuGet.SecureRemotePassword.Endpoints.RoleClaim.AddBulk;

using Administration;
using Application.RoleClaim.AddBulk;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Spoon.NuGet.EitherCore.Extensions;
using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;
using Spoon.NuGet.Mediator.PipelineBehaviors.Validation;
using Spoon.NuGet.SecureRemotePassword.Application.Administration.AddUserEmail;
using Spoon.NuGet.SecureRemotePassword.Contracts;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
/// </summary>
public static class RoleClaimAddBulkEndpoint
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapRoleClaimAddBulk(this IEndpointRouteBuilder app)
    {
        app.MapPut(ApiRoleClaimEndpoints.AddBulk.Endpoint,AddBulk)
            .WithName(ApiRoleClaimEndpoints.AddBulk.Name)
            .Produces(201)
            .Produces<PermissionFailed<AdministrationAddUserEmailResult>>(403)
            .Produces<Validationfailures>(406)
            .WithMetadata(new SwaggerOperationAttribute(ApiRoleClaimEndpoints.AddBulk.Summary, ApiRoleClaimEndpoints.AddBulk.Description));

        return app;
    }

    private static RoleClaimAddBulkCommand MapToCommand(this RoleClaimAddBulkCommandRequest request, Guid userId)
    {
        var command = new RoleClaimAddBulkCommand
        {
            UserId = userId,
            Claims = request.Claims,
        };

        return command;
    }

    private static async Task<IResult> AddBulk([FromRoute] Guid userId, [FromBody] RoleClaimAddBulkCommandRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = request.MapToCommand(userId);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}