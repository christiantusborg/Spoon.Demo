namespace Spoon.NuGet.SecureRemotePassword.Endpoints.UserRole.AddBulk;

using Application.UserRole.AddBulk;
using Core.Presentation;
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
public class UserRoleAddBulkEndpoint: IEndpointMarker
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapPut(ApiUserRoleEndpoints.AddBulk.Endpoint,AddBulk)
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
            Claims = request.Claims,
        };

        return command;
    }

    private async Task<IResult> AddBulk([FromRoute] Guid userId, [FromBody] UserRoleAddBulkCommandRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(request,userId);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}