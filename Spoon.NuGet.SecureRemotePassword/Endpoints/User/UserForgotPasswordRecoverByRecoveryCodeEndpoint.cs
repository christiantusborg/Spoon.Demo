namespace Spoon.NuGet.SecureRemotePassword.Endpoints.User;

using Application.User.UserForgotPasswordRecoverByRecoveryCodeInit;
using Contracts;
using EitherCore.Extensions;
using Extensions;
using Mediator.PipelineBehaviors.Permission;
using Mediator.PipelineBehaviors.Validation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
///     Spoon.NuGet.SecureRemotePassword.Api
/// </summary>
public static class UserForgotPasswordRecoverByRecoveryCodeEndpoint
{
    /// <summary>
    ///     Spoon.NuGet.SecureRemotePassword.Contracts
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapUserForgotPasswordRecoverByRecoveryCode(this IEndpointRouteBuilder app)
    {
        app.MapPost(ApiUserEndpoints.ForgotPasswordRecoverByRecoveryCode.Endpoint,
                async ([FromBody] UserForgotPasswordRecoverByRecoveryCodeRequest request, ISender sender, CancellationToken cancellationToken) =>
                {
                    var command = request.MapToCommand();
                    var commandResult = await sender.Send(command, cancellationToken);
                    var result = commandResult.ToNoContent();

                    return result;
                })
            .WithName(nameof(ApiUserEndpoints.ForgotPasswordRecoverByRecoveryCode))
            .Produces(204)
            .Produces(404)
            .Produces<Validationfailures>(406)
            .Produces<PermissionFailed<UserForgotPasswordRecoverByRecoveryCodeCommandResult>>(403)
            .WithMetadata(new SwaggerOperationAttribute(ApiUserEndpoints.ForgotPasswordRecoverByRecoveryCode.Summary, ApiUserEndpoints.ForgotPasswordRecoverByRecoveryCode.Description));

        return app;
    }

    private static UserForgotPasswordRecoverByRecoveryCodeCommand MapToCommand(this UserForgotPasswordRecoverByRecoveryCodeRequest request)
    {
        var command = new UserForgotPasswordRecoverByRecoveryCodeCommand
        {
            Email = request.Email,
            Salt = request.Salt,
            Verifier = request.Verifier,
            RecoveryCode = request.RecoveryCode,
        };
        return command;
    }
}