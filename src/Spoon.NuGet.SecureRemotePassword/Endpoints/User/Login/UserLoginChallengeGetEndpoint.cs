namespace Spoon.NuGet.SecureRemotePassword.Endpoints.User.Login;

using Application.Commands.Users.UserGetLoginChallenge;
using Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
/// </summary>
public class UserLoginChallengeGetEndpoint //: IEndpointMarker
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapPost(ApiUserEndpoints.GetLoginChallenge.Endpoint, async ([FromBody] UserGetLoginChallengeRequest request, ISender sender, CancellationToken cancellationToken) =>
            {
                var command = this.MapToCommand(request);

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
            UsernameHashed = request.UsernameHashed, 
        };
        return command;
    }
}