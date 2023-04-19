// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable MemberCanBePrivate.Global

namespace Spoon.NuGet.SecureRemotePassword.Endpoints.User.Logout;

using System.Security.Claims;
using Application.Commands.Users.UserLogout;
using Application.Commands.Users.UserLogoutAll;
using Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
/// </summary>
public class UserLogoutAllEndpoint //: IEndpointMarker
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapGet(ApiUserEndpoints.LogoutAll.Endpoint, this.Logout)
            .WithName(nameof(ApiUserEndpoints.LogoutAll.Name))
            .WithTags(ApiUserEndpoints.Tag)
            .Produces(204)
            .Produces<Validationfailures>(406)
            .Produces<PermissionFailed<UserLogoutCommand>>(403)
            .WithMetadata(new SwaggerOperationAttribute(ApiUserEndpoints.LogoutAll.Summary, ApiUserEndpoints.LogoutAll.Description));
        return app;
    }

    private UserLogoutAllCommand MapToCommand(Guid userId)
    {
        var command = new UserLogoutAllCommand
        {
            UserId = userId,
        };

        return command;
    }

    internal async Task<IResult> Logout(ClaimsPrincipal claimsPrincipal, ISender sender, CancellationToken cancellationToken)
    {
        var command = this.MapToCommand(ClaimsPrincipalExtensions.GetUserId(claimsPrincipal));

        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}