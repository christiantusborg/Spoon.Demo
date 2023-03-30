namespace Spoon.NuGet.SecureRemotePassword.Endpoints.User.Login;

using Application.Users.UserSubmitLoginChallenge;
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
public class UserSubmitLoginChallengeEndpoint : IEndpointMarker
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapPost(ApiUserEndpoints.SubmitLoginChallenge.Endpoint,  async ([FromBody] UserSubmitLoginChallengeRequest request, ISender sender, CancellationToken cancellationToken) =>
            {
                var command = MapToCommand(request);

                var commandResult = await sender.Send(command, cancellationToken);
                var result = commandResult.ToResult(typeof(UserGetLoginChallengeResult));

                return result;
            })
            .WithName(nameof(ApiUserEndpoints.SubmitLoginChallenge))
            .Produces<UserSubmitLoginChallengeResult>()
            .Produces<Validationfailures>(406)
            .Produces<PermissionFailed<UserSubmitLoginChallengeResult>>(403)
            .WithMetadata(new SwaggerOperationAttribute(ApiUserEndpoints.SubmitLoginChallenge.Summary, ApiUserEndpoints.SubmitLoginChallenge.Description));
        return app;
    }
    
    private UserSubmitLoginChallengeCommand MapToCommand(UserSubmitLoginChallengeRequest request)
    {
        var command = new UserSubmitLoginChallengeCommand
        {
            UserId = request.UserId,
            ClientSessionProof = request.ClientSessionProof
        };
        return command;
    }
}