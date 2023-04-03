// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable MemberCanBePrivate.Global
namespace Spoon.NuGet.SecureRemotePassword.Endpoints.User.Logout;

using System.Security.Claims;
using Application.Users.UserLogout;
using Core.Presentation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Spoon.NuGet.EitherCore.Extensions;
using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;
using Spoon.NuGet.Mediator.PipelineBehaviors.Validation;
using Spoon.NuGet.SecureRemotePassword.Extensions;
using Swashbuckle.AspNetCore.Annotations;
using ClaimsPrincipalExtensions = Extensions.ClaimsPrincipalExtensions;

//public static class GetChallengeAuthentication
/// <summary>
/// 
/// </summary>
public class UserLogoutEndpoint //: IEndpointMarker
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
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapGet(ApiUserEndpoints.Logout.Endpoint, Logout)
            .WithName(nameof(ApiUserEndpoints.Logout.Name))
            .WithTags(ApiUserEndpoints.Email.EmailTag)
            .Produces(204)
            .Produces<Validationfailures>(406)
            .Produces<PermissionFailed<UserLogoutCommand>>(403)
            .WithMetadata(new SwaggerOperationAttribute(ApiUserEndpoints.Logout.Summary, ApiUserEndpoints.Logout.Description));
        return app;
    }
    
    private UserLogoutCommand MapToCommand(Guid userId, Guid sessionId)
    {
        
        var command = new UserLogoutCommand
        {
            UserId = userId,
            Session = sessionId, 
        };
        
        return command;
    }
    
    internal async Task<IResult> Logout(ClaimsPrincipal claimsPrincipal, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(ClaimsPrincipalExtensions.GetUserId(claimsPrincipal),claimsPrincipal.GetSessionId());

        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}