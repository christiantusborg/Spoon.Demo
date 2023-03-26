namespace Spoon.NuGet.SecureRemotePassword.Endpoints.UserRole.AddBulk;

using Application.UserRole.AddBulk;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Spoon.NuGet.EitherCore.Extensions;
using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;
using Spoon.NuGet.Mediator.PipelineBehaviors.Validation;
using Spoon.NuGet.SecureRemotePassword.Application.UserClaim.AddBulk;
using Spoon.NuGet.SecureRemotePassword.Contracts;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
/// </summary>
public static class UserRoleAddBulkEndpoint
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapUserRoleAddBulk(this IEndpointRouteBuilder app)
    {
        app.MapPut(ApiUserRoleEndpoints.AddBulk.Endpoint,AddBulk)
            .WithName(ApiUserRoleEndpoints.AddBulk.Name)
            .Produces(201)
            .Produces<PermissionFailed<AdministrationAddUserEmailResult>>(403)
            .Produces<Validationfailures>(406)
            .WithMetadata(new SwaggerOperationAttribute(ApiUserRoleEndpoints.AddBulk.Summary, ApiUserRoleEndpoints.AddBulk.Description));

        return app;
    }

    private static UserRoleAddBulkCommand MapToCommand(this UserRoleAddBulkCommandRequest request, Guid userId)
    {
        var command = new UserRoleAddBulkCommand
        {
            UserId = userId,
            Claims = request.Claims,
        };

        return command;
    }

    private static async Task<IResult> AddBulk([FromRoute] Guid userId, [FromBody] UserRoleAddBulkCommandRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = request.MapToCommand(userId);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}