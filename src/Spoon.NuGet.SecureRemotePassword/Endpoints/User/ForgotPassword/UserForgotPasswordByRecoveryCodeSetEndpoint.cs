namespace Spoon.NuGet.SecureRemotePassword.Endpoints.User.ForgotPassword;

using Application.Commands.Users.UserForgotPasswordRecoverByRecoveryCodeChallengeGet;
using Application.Commands.Users.UserForgotPasswordRecoverByRecoveryCodeSet;
using Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
///     Spoon.NuGet.SecureRemotePassword.Api
/// </summary>
public class UserForgotPasswordByRecoveryCodeSetEndpoint // : IEndpointMarker
{
    /// <summary>
    ///     Spoon.NuGet.SecureRemotePassword.Contracts
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapPost(ApiUserEndpoints.ForgotPasswordRecoverByRecoveryCode.ChallengeGet.Endpoint,SetUserPassword)
            .WithName(ApiUserEndpoints.ForgotPasswordRecoverByRecoveryCode.ChallengeGet.Name)
            .Produces(204)
            .Produces(404)
            .Produces<Validationfailures>(406)
            .Produces<PermissionFailed<UserForgotPasswordRecoverByRecoveryCodeChallengeGetCommandResult>>(403)
            .WithMetadata(new SwaggerOperationAttribute(ApiUserEndpoints.ForgotPasswordRecoverByRecoveryCode.ChallengeGet.Summary,
                ApiUserEndpoints.ForgotPasswordRecoverByRecoveryCode.ChallengeGet.Description));

        return app;
    }

    private static  UserForgotPasswordRecoverByRecoveryCodeSetCommand MapToCommand(UserForgotPasswordRecoverByRecoveryCodeRequest request)
    {
        var command = new  UserForgotPasswordRecoverByRecoveryCodeSetCommand
        {
            UsernameHashed = request.UsernameHashed,
            Salt = request.Salt,
            Verifier = request.Verifier,
        };

        return command;
    }

    private static async Task<IResult> SetUserPassword([FromRoute] Guid userId, [FromBody] UserForgotPasswordRecoverByRecoveryCodeRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(request);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}