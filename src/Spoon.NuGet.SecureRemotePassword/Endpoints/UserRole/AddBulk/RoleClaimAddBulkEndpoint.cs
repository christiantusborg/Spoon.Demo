namespace Spoon.NuGet.SecureRemotePassword.Endpoints.UserRole.AddBulk;

using Application.Commands.UserRole.AddBulk;
using Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
/// </summary>
public class UserRoleAddBulkEndpoint //: IEndpointMarker
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapPut(ApiUserRoleEndpoints.AddBulk.Endpoint, this.AddBulk)
            .WithName(ApiUserRoleEndpoints.AddBulk.Name)
            .Produces(201)
            .Produces<PermissionFailed<AdministrationAddUserEmailResult>>(403)
            .Produces<Validationfailures>(406)
            .WithMetadata(new SwaggerOperationAttribute(ApiUserRoleEndpoints.AddBulk.Summary, ApiUserRoleEndpoints.AddBulk.Description));

        return app;
    }

    private UserRoleAddBulkCommand MapToCommand(UserRoleAddBulkCommandRequest request, Guid userId)
    {
        var command = new UserRoleAddBulkCommand
        {
            UserId = userId,
            Roles = request.Roles,
        };

        return command;
    }

    private async Task<IResult> AddBulk([FromRoute] Guid userId, [FromBody] UserRoleAddBulkCommandRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = this.MapToCommand(request, userId);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}