namespace Spoon.NuGet.SecureRemotePassword.Endpoints.UserClaim.RemoveBulk;

using Core.Presentation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Spoon.NuGet.EitherCore.Extensions;
using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;
using Spoon.NuGet.Mediator.PipelineBehaviors.Validation;
using Spoon.NuGet.SecureRemotePassword.Application.UserClaim.RemoveBulk;
using Spoon.NuGet.SecureRemotePassword.Contracts;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
/// </summary>
public class UserClaimRemoveBulkEndpoint : IEndpointMarker
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapPut(ApiUserClaimEndpoints.RemoveBulk.Endpoint,RemoveBulk)
            .WithName(ApiUserClaimEndpoints.RemoveBulk.Name)
            .Produces(201)
            .Produces<PermissionFailed<AdministrationRemoveUserEmailResult>>(403)
            .Produces<Validationfailures>(406)
            .WithMetadata(new SwaggerOperationAttribute(ApiUserClaimEndpoints.RemoveBulk.Summary, ApiUserClaimEndpoints.RemoveBulk.Description));

        return app;
    }

    private UserClaimRemoveBulkCommand MapToCommand( UserClaimRemoveBulkCommandRequest request, Guid userId)
    {
        var command = new UserClaimRemoveBulkCommand
        {
            UserId = userId,
            Claims = request.Claims,
        };

        return command;
    }

    private async Task<IResult> RemoveBulk([FromRoute] Guid userId, [FromBody] UserClaimRemoveBulkCommandRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(request,userId);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}