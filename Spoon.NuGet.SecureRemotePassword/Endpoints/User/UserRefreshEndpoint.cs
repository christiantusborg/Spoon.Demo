namespace Spoon.NuGet.SecureRemotePassword.Endpoints.User;

using Application.User.UserRefresh;
using Extensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.AspNetCore.Routing;
using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;
using Spoon.NuGet.Mediator.PipelineBehaviors.Validation;
using Spoon.NuGet.SecureRemotePassword.Contracts;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
/// 
/// </summary>
public static class UserRefreshEndpoint
{
   

    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapUserRefresh(this IEndpointRouteBuilder app)
    {
        app.MapPost(ApiUserEndpoints.Refresh.Endpoint,  async ([AsParameters] UserRefreshRequest request, IOutputCacheStore outputCacheStore, ISender sender, CancellationToken cancellationToken) =>
            {
                var command = request.MapToCommand();

                var commandResult = await sender.Send(command, cancellationToken);

                return Results.NoContent();
            })
            .WithName(nameof(ApiUserEndpoints.Refresh))
            .Produces<UserRefreshResult>()
            .Produces<Validationfailures>(406)
            .Produces<PermissionFailed<UserRefreshResult>>(403)
            .WithMetadata(new SwaggerOperationAttribute(ApiUserEndpoints.Refresh.Summary, ApiUserEndpoints.Refresh.Description));
        
        return app;
    }
    
    private static UserRefreshCommand MapToCommand(this UserRefreshRequest request)
    {
        var command = new UserRefreshCommand
        {
            RefreshToken = request.RefreshToken,
        };
        return command;
    }
}