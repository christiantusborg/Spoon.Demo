namespace Spoon.NuGet.SecureRemotePassword.Endpoints.RoleClaim.AddBulk;

using Administration;
using Application.RolesClaims.AddBulk;
using Core.Presentation;
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
public class RoleClaimAddBulkEndpoint : IEndpointMarker
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapPut(ApiRoleClaimEndpoints.AddBulk.Endpoint,AddBulk)
            .WithName(ApiRoleClaimEndpoints.AddBulk.Name)
            .Produces(201)
            .Produces<PermissionFailed<AdministrationAddUserEmailResult>>(403)
            .Produces<Validationfailures>(406)
            .WithMetadata(new SwaggerOperationAttribute(ApiRoleClaimEndpoints.AddBulk.Summary, ApiRoleClaimEndpoints.AddBulk.Description));

        return app;
    }

    private RoleClaimAddBulkCommand MapToCommand(RoleClaimAddBulkCommandRequest request, Guid userId)
    {
        var command = new RoleClaimAddBulkCommand
        {
            UserId = userId,
            Claims = request.Claims,
        };

        return command;
    }

    private async Task<IResult> AddBulk([FromRoute] Guid userId, [FromBody] RoleClaimAddBulkCommandRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(request,userId);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}