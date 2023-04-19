namespace Spoon.NuGet.SecureRemotePassword.Endpoints.UserRole.RemoveBulk;

using Application.Commands.UserRole.RemoveBulk;
using Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
/// </summary>
public class UserRoleRemoveBulkEndpoint // : IEndpointMarker
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapPut(ApiUserRoleEndpoints.RemoveBulk.Endpoint, this.RemoveBulk)
            .WithName(ApiUserRoleEndpoints.RemoveBulk.Name)
            .Produces(201)
            .Produces<PermissionFailed<AdministrationRemoveUserEmailResult>>(403)
            .Produces<Validationfailures>(406)
            .WithMetadata(new SwaggerOperationAttribute(ApiUserRoleEndpoints.RemoveBulk.Summary, ApiUserRoleEndpoints.RemoveBulk.Description));

        return app;
    }

    private static UserRoleRemoveBulkCommand MapToCommand(UserRoleRemoveBulkCommandRequest request, Guid userId)
    {
        var command = new UserRoleRemoveBulkCommand
        {
            UserId = userId,
            Roles = request.Roles,
        };

        return command;
    }

    private async Task<IResult> RemoveBulk([FromRoute] Guid userId, [FromBody] UserRoleRemoveBulkCommandRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(request, userId);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}