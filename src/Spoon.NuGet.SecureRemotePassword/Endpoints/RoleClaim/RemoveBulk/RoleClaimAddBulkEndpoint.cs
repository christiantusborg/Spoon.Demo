namespace Spoon.NuGet.SecureRemotePassword.Endpoints.RoleClaim.RemoveBulk;

using Application.Commands.RolesClaims.RemoveBulk;
using Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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
        app.MapPut(ApiRoleClaimEndpoints.RemoveBulk.Endpoint, this.RemoveBulk)
            .WithName(ApiRoleClaimEndpoints.RemoveBulk.Name)
            .Produces(201)
            .Produces<PermissionFailed<AdministrationRemoveUserEmailResult>>(403)
            .Produces<Validationfailures>(406)
            .WithMetadata(new SwaggerOperationAttribute(ApiRoleClaimEndpoints.RemoveBulk.Summary, ApiRoleClaimEndpoints.RemoveBulk.Description));

        return app;
    }

    private RoleClaimRemoveBulkCommand MapToCommand(RoleClaimRemoveBulkCommandRequest request, Guid roleId)
    {
        var command = new RoleClaimRemoveBulkCommand
        {
            RoleId = roleId,
            Claims = request.Claims,
        };

        return command;
    }

    private async Task<IResult> RemoveBulk([FromRoute] Guid roleId, [FromBody] RoleClaimRemoveBulkCommandRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = this.MapToCommand(request, roleId);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}