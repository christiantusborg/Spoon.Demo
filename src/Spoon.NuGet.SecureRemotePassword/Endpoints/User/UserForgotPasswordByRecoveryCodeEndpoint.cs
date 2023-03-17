namespace Spoon.NuGet.SecureRemotePassword.Endpoints.User.ForgotPassword;

using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Spoon.NuGet.EitherCore.Extensions;
using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;
using Spoon.NuGet.Mediator.PipelineBehaviors.Validation;
using Spoon.NuGet.SecureRemotePassword.Application.User.UserForgotPasswordRecoverByRecoveryCodeInit;
using Spoon.NuGet.SecureRemotePassword.Contracts;
using Spoon.NuGet.SecureRemotePassword.Endpoints.User.Extensions;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
///     Spoon.NuGet.SecureRemotePassword.Api
/// </summary>
public static class UserForgotPasswordByRecoveryCodeEndpoint
{
    /// <summary>
    ///     Spoon.NuGet.SecureRemotePassword.Contracts
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapUserForgotPasswordByRecoveryCode(this IEndpointRouteBuilder app)
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