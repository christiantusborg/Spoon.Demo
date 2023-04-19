namespace Spoon.NuGet.SecureRemotePassword.Endpoints.User.Refresh;

using System.Security.Claims;
using Application.Commands.Users.UserRefresh;
using Contracts;
using Core.Presentation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
/// </summary>
public class UserRefreshEndpoint //: IEndpointMarker
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapPost(ApiUserEndpoints.Refresh.Endpoint, async ([AsParameters] UserRefreshRequest request, ClaimsPrincipal claimsPrincipal, ISender sender, CancellationToken cancellationToken) =>
            {
                var userId = claimsPrincipal.GetUserId();
                var command = this.MapToCommand(request, claimsPrincipal.GetUserId(), claimsPrincipal.GetIat(), claimsPrincipal.GetSessionId(), claimsPrincipal.GetRefreshTokenVerifier());


                var commandResult = await sender.Send(command, cancellationToken);

                return Results.NoContent();
            })
            .WithName(ApiUserEndpoints.Refresh.Name)
            .Produces<UserRefreshResult>()
            .Produces<Validationfailures>(406)
            .Produces<PermissionFailed<UserRefreshResult>>(403)
            .WithMetadata(new SwaggerOperationAttribute(ApiUserEndpoints.Refresh.Summary, ApiUserEndpoints.Refresh.Description));

        return app;
    }

    private UserRefreshCommand MapToCommand(UserRefreshRequest request, Guid userId,long iat, Guid sessionId, string refreshTokenVerifier)
    {
        var command = new UserRefreshCommand
        {
            RefreshToken = request.RefreshToken,
            Iat = iat,
            UserId = userId,
            SessionId = sessionId,
            RefreshTokenVerifier = refreshTokenVerifier, 
                
            
        };
        return command;
    }
}