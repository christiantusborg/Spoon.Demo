namespace Spoon.NuGet.SecureRemotePassword.Endpoints.User.Login;

using Application.Commands.Users.UserSubmitLoginChallenge;
using Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
/// </summary>
public class UserSubmitLoginChallengeEndpoint // : IEndpointMarker
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapPost(ApiUserEndpoints.SubmitLoginChallenge.Endpoint, async ([FromBody] UserSubmitLoginChallengeRequest request, HttpContext context  , ISender sender, CancellationToken cancellationToken) =>
            {
                

                string? ipAddress = context?.Connection?.RemoteIpAddress?.ToString();
                string? userAgent = context?.Request.Headers["User-Agent"].ToString();
                var command = this.MapToCommand(request,ipAddress,userAgent);
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

    private UserSubmitLoginChallengeCommand MapToCommand(UserSubmitLoginChallengeRequest request, string? ipAddress, string? userAgent)
    {
        var command = new UserSubmitLoginChallengeCommand
        {
            UserId = request.UserId,
            IpAddress = ipAddress ?? string.Empty,
            UserAgent = userAgent ?? string.Empty,
        };
        return command;
    }
}