namespace Spoon.NuGet.SecureRemotePassword.Endpoints.User.ForgotPassword;

using Application.Users.UserForgotPasswordRecoverByRecoveryCodeChallengeGet;
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
///     Spoon.NuGet.SecureRemotePassword.Api
/// </summary>
public static class UserForgotPasswordByRecoveryCodeSetEndpoint
{
    /// <summary>
    ///     Spoon.NuGet.SecureRemotePassword.Contracts
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapUserForgotPasswordByRecoveryCodeSet(this IEndpointRouteBuilder app)
    {
        app.MapPost(ApiUserEndpoints.ForgotPasswordRecoverByRecoveryCode.ChallengeGet.Endpoint,
                async ([FromBody] UserForgotPasswordRecoverByRecoveryCodeRequest request, ISender sender, CancellationToken cancellationToken) =>
                {
                    var command = request.MapToCommand();
                    var commandResult = await sender.Send(command, cancellationToken);
                    var result = commandResult.ToNoContent();

                    return result;
                })
            .WithName(ApiUserEndpoints.ForgotPasswordRecoverByRecoveryCode.ChallengeGet.Name)
            .Produces(204)
            .Produces(404)
            .Produces<Validationfailures>(406)
            .Produces<PermissionFailed<UserForgotPasswordRecoverByRecoveryCodeChallengeGetCommandResult>>(403)
            .WithMetadata(new SwaggerOperationAttribute(ApiUserEndpoints.ForgotPasswordRecoverByRecoveryCode.ChallengeGet.Summary,ApiUserEndpoints.ForgotPasswordRecoverByRecoveryCode.ChallengeGet.Description));

        return app;
    }

    private static UserForgotPasswordRecoverByRecoveryCodeChallengeGetCommand MapToCommand(this UserForgotPasswordRecoverByRecoveryCodeRequest request)
    {
        var command = new UserForgotPasswordRecoverByRecoveryCodeChallengeGetCommand
        {
            Email = request.Email,
        };

        return command;
    }
}