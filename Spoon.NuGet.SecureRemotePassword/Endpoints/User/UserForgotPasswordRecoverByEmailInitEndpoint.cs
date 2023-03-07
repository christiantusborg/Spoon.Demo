namespace Spoon.NuGet.SecureRemotePassword.Endpoints.User;

using Application.User.UserForgotPasswordRecoverByEmailInit;
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
public static class UserForgotPasswordRecoverByEmailInitEndpoint
{
    /// <summary>
    /// </summary>
    public const string Name = "UserForgotPasswordRecoverByEmailInit";

    /// <summary>
    ///     Spoon.NuGet.SecureRemotePassword.Contracts
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapUserForgotPasswordRecoverByEmailInit(this IEndpointRouteBuilder app)
    {
        app.MapPost(ApiUserEndpoints.ForgotPasswordRecoverByEmailInit.Endpoint,
                async ([FromBody] UserForgotPasswordRecoverByEmailInitRequest request, ISender sender, CancellationToken cancellationToken) =>
                {
                    var command = request.MapToCommand();

                    var commandResult = await sender.Send(command, cancellationToken);
                    var result = commandResult.ToNoContent();

                    return result;
                })
            .WithName(Name)
            .Produces(204)
            .Produces(404)
            .Produces<Validationfailures>(406)
            .WithMetadata(new SwaggerOperationAttribute(ApiUserEndpoints.ForgotPasswordRecoverByEmailInit.Summary, ApiUserEndpoints.ForgotPasswordRecoverByEmailInit.Description));

        return app;
    }

    private static UserForgotPasswordRecoverByEmailInitCommand MapToCommand(this UserForgotPasswordRecoverByEmailInitRequest request)
    {
        var command = new UserForgotPasswordRecoverByEmailInitCommand
        {
            Email = request.Email,
        };
        return command;
    }
}