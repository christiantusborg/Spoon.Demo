namespace Spoon.NuGet.SecureRemotePassword.Endpoints.UserClaim.AddBulk;

using Application.UserClaim.AddBulk;
using Contracts;
using EitherCore.Extensions;
using Mediator.PipelineBehaviors.Permission;
using Mediator.PipelineBehaviors.Validation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
/// </summary>
public static class UserClaimAddBulkEndpoint
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapUserClaimAddBulk(this IEndpointRouteBuilder app)
    {
        app.MapPut(ApiUserClaimEndpoints.AddBulk.Endpoint, AddBulk)
            .WithName(ApiUserClaimEndpoints.AddBulk.Name)
            .Produces(201)
            .Produces<PermissionFailed<AdministrationAddUserEmailResult>>(403)
            .Produces<Validationfailures>(406)
            .WithMetadata(new SwaggerOperationAttribute(ApiUserClaimEndpoints.AddBulk.Summary, ApiUserClaimEndpoints.AddBulk.Description));

        return app;
    }

    private static UserClaimAddBulkCommand MapToCommand(this UserClaimAddBulkCommandRequest request, Guid userId)
    {
        var command = new UserClaimAddBulkCommand
        {
            UserId = userId,
            Claims = request.Claims
         
        };

        return command;
    }

    private static async Task<IResult> AddBulk([FromRoute] Guid userId, [FromBody] UserClaimAddBulkCommandRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = request.MapToCommand(userId);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}