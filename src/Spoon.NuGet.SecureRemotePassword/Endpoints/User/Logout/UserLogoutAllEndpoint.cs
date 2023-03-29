﻿// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable MemberCanBePrivate.Global
namespace Spoon.NuGet.SecureRemotePassword.Endpoints.User.Logout;

using System.Security.Claims;
using Application.Users.UserLogout;
using Application.Users.UserLogoutAll;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Spoon.NuGet.EitherCore.Extensions;
using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;
using Spoon.NuGet.Mediator.PipelineBehaviors.Validation;
using Spoon.NuGet.SecureRemotePassword.Extensions;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
/// 
/// </summary>
public static class UserLogoutAllEndpoint
{


    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapUserLogoutAll(this IEndpointRouteBuilder app)
    {
        app.MapGet(ApiUserEndpoints.LogoutAll.Endpoint, Logout)
            .WithName(nameof(ApiUserEndpoints.LogoutAll.Name))
            .WithTags(ApiUserEndpoints.Tag)
            .Produces(204)
            .Produces<Validationfailures>(406)
            .Produces<PermissionFailed<UserLogoutCommand>>(403)
            .WithMetadata(new SwaggerOperationAttribute(ApiUserEndpoints.LogoutAll.Summary, ApiUserEndpoints.LogoutAll.Description));
        return app;
    }
    
    private static UserLogoutAllCommand MapToCommand(Guid userId)
    {
        
        var command = new UserLogoutAllCommand
        {
            UserId = userId,
        };
        
        return command;
    }
    
    internal static async Task<IResult> Logout(ClaimsPrincipal claimsPrincipal, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(claimsPrincipal.GetUserId());

        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}