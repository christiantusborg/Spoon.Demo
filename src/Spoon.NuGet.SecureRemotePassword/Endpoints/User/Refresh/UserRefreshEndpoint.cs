namespace Spoon.NuGet.SecureRemotePassword.Endpoints.User.Refresh;

using Application.Users.UserRefresh;
using Core.Presentation;
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
public class UserRefreshEndpoint //: IEndpointMarker
{
   

    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapPost(ApiUserEndpoints.Refresh.Endpoint,  async ([AsParameters] UserRefreshRequest request, IOutputCacheStore outputCacheStore, ISender sender, CancellationToken cancellationToken) =>
            {
                var command = MapToCommand(request);

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
    
    private UserRefreshCommand MapToCommand(UserRefreshRequest request)
    {
        var command = new UserRefreshCommand
        {
            RefreshToken = request.RefreshToken,
        };
        return command;
    }
}