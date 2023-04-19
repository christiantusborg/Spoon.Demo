namespace Spoon.NuGet.SecureRemotePassword.Endpoints.User.ForgotPassword;

using Application.Commands.Users.UserForgotPasswordRecoverByRecoveryCodeChallengeGet;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
///     Spoon.NuGet.SecureRemotePassword.Api
/// </summary>
public class UserForgotPasswordByRecoveryCodeChallengeGetEndpoint // : IEndpointMarker
{
    /// <summary>
    ///     Spoon.NuGet.SecureRemotePassword.Contracts
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapPost(ApiUserEndpoints.ForgotPasswordRecoverByRecoveryCode.ChallengeGet.Endpoint, this.ForgotPasswordByRecoveryCodeChallengeGetAsync)
            .WithName(ApiUserEndpoints.ForgotPasswordRecoverByRecoveryCode.ChallengeGet.Name)
            .Produces(204)
            .Produces(404)
            .Produces<Validationfailures>(406)
            .Produces<PermissionFailed<UserForgotPasswordRecoverByRecoveryCodeChallengeGetCommandResult>>(403)
            .WithMetadata(new SwaggerOperationAttribute(ApiUserEndpoints.ForgotPasswordRecoverByRecoveryCode.ChallengeGet.Summary,
                ApiUserEndpoints.ForgotPasswordRecoverByRecoveryCode.ChallengeGet.Description));

        return app;
    }

    private UserForgotPasswordRecoverByRecoveryCodeChallengeGetCommand MapToCommand(string usernameHashed)
    {
        var command = new UserForgotPasswordRecoverByRecoveryCodeChallengeGetCommand
        {
            UsernameHashed = usernameHashed,
        };
        return command;
    }

    private async Task<IResult> ForgotPasswordByRecoveryCodeChallengeGetAsync(string usernameHashed, ISender sender, CancellationToken cancellationToken)
    {
        var command = this.MapToCommand(usernameHashed);

        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}