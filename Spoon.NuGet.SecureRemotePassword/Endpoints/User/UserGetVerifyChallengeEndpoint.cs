namespace Spoon.NuGet.SecureRemotePassword.Endpoints.User;

using Application.User.UserGetVerifyChallenge;
using EitherCore.Extensions;
using EndpointFilters;
using Extensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;
using Spoon.NuGet.Mediator.PipelineBehaviors.Validation;
using Spoon.NuGet.SecureRemotePassword.Contracts;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
/// 
/// </summary>
public static class UserGetVerifyChallengeEndpoint
{
     /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapUserGetVerifyChallenge(this IEndpointRouteBuilder app)
    {
        app.MapPost(ApiUserEndpoints.GetLoginChallenge.Endpoint,  async ([FromBody] UserGetVerifyChallengeRequest request ,ISender sender, CancellationToken cancellationToken) =>
            {
                
                var command = MapToCommand(request);

                var commandResult = await sender.Send(command, cancellationToken);
                var result = commandResult.ToResult(typeof(UserGetLoginChallengeResult));

                return result;
            })
            .WithName(nameof(ApiUserEndpoints.GetLoginChallenge))
            .Produces<UserGetVerifyChallengeResult>()
            .Produces<Validationfailures>(406)
            .Produces<PermissionFailed<UserGetVerifyChallengeResult>>(403)
            .WithMetadata(new SwaggerOperationAttribute(ApiUserEndpoints.GetLoginChallenge.Summary, ApiUserEndpoints.GetLoginChallenge.Description));
        
        return app;
    }

     private static UserGetVerifyChallengeCommand MapToCommand(UserGetVerifyChallengeRequest request)
     {
         var command = new UserGetVerifyChallengeCommand
         {
             Username = request.Username,
         };
         return command;
     }
}