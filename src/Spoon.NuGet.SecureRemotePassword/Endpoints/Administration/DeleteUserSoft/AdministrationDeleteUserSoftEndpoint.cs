namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Administration.DeleteUserSoft;

using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Spoon.NuGet.EitherCore.Extensions;
using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;
using Spoon.NuGet.Mediator.PipelineBehaviors.Validation;
using Spoon.NuGet.SecureRemotePassword.Application.Administration.DeleteUserSoft;
using Spoon.NuGet.SecureRemotePassword.Contracts;
using Spoon.NuGet.SecureRemotePassword.Extensions;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
/// 
/// </summary>
public static class AdministrationDeleteUserSoftEndpoint
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapAdministrationDeleteUserSoft(this IEndpointRouteBuilder app)
    {
        app.MapDelete(ApiAdministrationEndpoints.DeleteUserSoft.Endpoint,  DeleteUser)
            .WithName(nameof(ApiAdministrationEndpoints.DeleteUserSoft.Name))
            .Produces(204)
            .Produces<Validationfailures>(406)
            .Produces<PermissionFailed<AdministrationDeleteUserResult>>(403)
            .WithMetadata(new SwaggerOperationAttribute(ApiAdministrationEndpoints.DeleteUserSoft.Summary, ApiAdministrationEndpoints.DeleteUserSoft.Description));
        
        return app;
    }
    
    private static AdministrationDeleteUserSoftCommand MapToCommand(Guid userId, Guid currentUserId)
    {
        var command = new AdministrationDeleteUserSoftCommand
        {
            UserId = userId,
            CurrentUserId = currentUserId,
        };

        return command;
    }
    
    private static async Task<IResult> DeleteUser([FromRoute] Guid userId, ClaimsPrincipal claimsPrincipal, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(userId, claimsPrincipal.GetUserId());
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }  
}