namespace Spoon.NuGet.SecureRemotePassword.Endpoints.User.Login;

using Application.Users.UserGetLoginChallenge;
using Core.Presentation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Spoon.NuGet.EitherCore.Extensions;
using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;
using Spoon.NuGet.Mediator.PipelineBehaviors.Validation;
using Spoon.NuGet.SecureRemotePassword.Contracts;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
/// 
/// </summary>
public class UserLoginChallengeGetEndpoint //: IEndpointMarker
{
     /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapPost(ApiUserEndpoints.GetLoginChallenge.Endpoint,  async ([FromBody] UserGetLoginChallengeRequest request ,ISender sender, CancellationToken cancellationToken) =>
            {
                
                var command = MapToCommand(request);

                var commandResult = await sender.Send(command, cancellationToken);
                var result = commandResult.ToResult(typeof(UserGetLoginChallengeResult));

                return result;
            })
            .WithName(nameof(ApiUserEndpoints.GetLoginChallenge))
            .Produces<UserGetLoginChallengeResult>()
            .Produces<Validationfailures>(406)
            .Produces<PermissionFailed<UserGetLoginChallengeResult>>(403)
            .WithMetadata(new SwaggerOperationAttribute(ApiUserEndpoints.GetLoginChallenge.Summary, ApiUserEndpoints.GetLoginChallenge.Description));
        
        return app;
    }

     private UserGetLoginChallengeCommand MapToCommand(UserGetLoginChallengeRequest request)
     {
         var command = new UserGetLoginChallengeCommand
         {
             Username = request.Username,
         };
         return command;
     }
}