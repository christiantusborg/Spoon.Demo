namespace Spoon.NuGet.SecureRemotePassword.Endpoints.RoleClaim.RemoveBulk;

using Application.RolesClaims.RemoveBulk;
using Core.Presentation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Spoon.NuGet.EitherCore.Extensions;
using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;
using Spoon.NuGet.Mediator.PipelineBehaviors.Validation;
using Spoon.NuGet.SecureRemotePassword.Contracts;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
/// </summary>
public class RoleClaimRemoveBulkEndpoint // : IEndpointMarker
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapPut(ApiRoleClaimEndpoints.RemoveBulk.Endpoint,RemoveBulk)
            .WithName(ApiRoleClaimEndpoints.RemoveBulk.Name)
            .Produces(201)
            .Produces<PermissionFailed<AdministrationRemoveUserEmailResult>>(403)
            .Produces<Validationfailures>(406)
            .WithMetadata(new SwaggerOperationAttribute(ApiRoleClaimEndpoints.RemoveBulk.Summary, ApiRoleClaimEndpoints.RemoveBulk.Description));

        return app;
    }

    private  RoleClaimRemoveBulkCommand MapToCommand(RoleClaimRemoveBulkCommandRequest request, Guid userId)
    {
        var command = new RoleClaimRemoveBulkCommand
        {
            UserId = userId,
            Claims = request.Claims,
        };

        return command;
    }

    private async Task<IResult> RemoveBulk([FromRoute] Guid userId, [FromBody] RoleClaimRemoveBulkCommandRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(request,userId);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}