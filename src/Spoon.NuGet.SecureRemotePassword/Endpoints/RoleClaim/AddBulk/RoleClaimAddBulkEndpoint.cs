namespace Spoon.NuGet.SecureRemotePassword.Endpoints.RoleClaim.AddBulk;

using Application.Commands.RolesClaims.AddBulk;
using Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
/// </summary>
public class RoleClaimAddBulkEndpoint // : IEndpointMarker
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapPut(ApiRoleClaimEndpoints.AddBulk.Endpoint, this.AddBulk)
            .WithName(ApiRoleClaimEndpoints.AddBulk.Name)
            .Produces(201)
            .Produces<PermissionFailed<AdministrationAddUserEmailResult>>(403)
            .Produces<Validationfailures>(406)
            .WithMetadata(new SwaggerOperationAttribute(ApiRoleClaimEndpoints.AddBulk.Summary, ApiRoleClaimEndpoints.AddBulk.Description));

        return app;
    }

    private RoleClaimAddBulkCommand MapToCommand(RoleClaimAddBulkCommandRequest request, Guid roleId)
    {
        var command = new RoleClaimAddBulkCommand
        {
            RoleId = roleId,
            Claims = request.Claims,
        };

        return command;
    }

    private async Task<IResult> AddBulk([FromRoute] Guid roleId, [FromBody] RoleClaimAddBulkCommandRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = this.MapToCommand(request, roleId);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}