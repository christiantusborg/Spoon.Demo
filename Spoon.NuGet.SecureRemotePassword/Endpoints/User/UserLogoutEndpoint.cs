namespace Spoon.NuGet.SecureRemotePassword.Endpoints.User;

using System.Security.Claims;
using Application.User.UserLogout;
using Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.AspNetCore.Routing;
using SecureRemotePassword.Extensions;
using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;
using Spoon.NuGet.Mediator.PipelineBehaviors.Validation;
using Spoon.NuGet.SecureRemotePassword.Contracts;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
/// 
/// </summary>
public static class UserLogoutEndpoint
{
    /// <summary>
    /// 
    /// </summary>
    public const string Name = "LogoutAuthentication";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapUserLogout(this IEndpointRouteBuilder app)
    {
        app.MapPost(ApiUserEndpoints.Logout.Endpoint,  
           
                async (ClaimsPrincipal claimsPrincipal, ISender sender, CancellationToken cancellationToken) =>
            {
                var command = MapToCommand(claimsPrincipal.GetUserId());

                var commandResult = await sender.Send(command, cancellationToken);

                return Results.NoContent();
            })
            .WithName(Name)
            .Produces<UserLogoutResult>()
            .Produces<Validationfailures>(406)
            .Produces<PermissionFailed<UserLogoutResult>>(403)
            
            .WithMetadata(new SwaggerOperationAttribute(ApiUserEndpoints.Logout.Summary, ApiUserEndpoints.Logout.Description));
        
        return app;
    }
    
    private static UserLogoutCommand MapToCommand(Guid userId)
    {
        var command = new UserLogoutCommand
        {
            userId = userId,
        };
        return command;
    }
}