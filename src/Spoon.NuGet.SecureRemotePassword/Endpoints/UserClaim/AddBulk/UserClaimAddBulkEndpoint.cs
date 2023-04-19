namespace Spoon.NuGet.SecureRemotePassword.Endpoints.UserClaim.AddBulk;

using Application.Commands.UserClaim.AddBulk;
using Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
/// </summary>
public class UserClaimAddBulkEndpoint //: IEndpointMarker
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapPut(ApiUserClaimEndpoints.AddBulk.Endpoint, this.AddBulk)
            .WithName(ApiUserClaimEndpoints.AddBulk.Name)
            .Produces(201)
            .Produces<PermissionFailed<AdministrationAddUserEmailResult>>(403)
            .Produces<Validationfailures>(406)
            .WithMetadata(new SwaggerOperationAttribute(ApiUserClaimEndpoints.AddBulk.Summary, ApiUserClaimEndpoints.AddBulk.Description));

        return app;
    }

    private UserClaimAddBulkCommand MapToCommand(UserClaimAddBulkCommandRequest request, Guid userId)
    {
        var command = new UserClaimAddBulkCommand
        {
            UserId = userId,
            Claims = request.Claims,
        };

        return command;
    }

    private async Task<IResult> AddBulk([FromRoute] Guid userId, [FromBody] UserClaimAddBulkCommandRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = this.MapToCommand(request, userId);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}