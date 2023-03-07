namespace Spoon.NuGet.SecureRemotePassword.Endpoints.User;

using Application.User.UserForgotPasswordRecoverByEmailSet;
using Contracts;
using EitherCore.Extensions;
using EndpointFilters;
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
public static class UserForgotPasswordRecoverByEmailSetEndpoint
{
    /// <summary>
    ///     Spoon.NuGet.SecureRemotePassword.Contracts
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapUserForgotPasswordRecoverByEmailSet(this IEndpointRouteBuilder app)
    {
        app.MapPost(ApiUserEndpoints.ForgotPasswordRecoverByEmailSet.Endpoint,
                async ([FromBody] UserForgotPasswordRecoverByEmailSetRequest request, ISender sender, CancellationToken cancellationToken) =>
                {
                    var command = request.MapToCommand();
                    
                    var commandResult = await sender.Send(command, cancellationToken);
                    var result = commandResult.ToNoContent();

                    return result;
                })
            .WithName(nameof(ApiUserEndpoints.ForgotPasswordRecoverByEmailSet))
            .Produces(204)
            .Produces(404)
            .Produces<Validationfailures>(406)
            .Produces<PermissionFailed<ForgotPasswordRecoverByEmailAuthenticationResult>>(403)
            .AddEndpointFilter<VerifyProofEndpointFilter>()
            .WithMetadata(new SwaggerOperationAttribute(ApiUserEndpoints.ForgotPasswordRecoverByEmailSet.Summary, ApiUserEndpoints.ForgotPasswordRecoverByEmailSet.Description));

        return app;
    }

    private static UserForgotPasswordRecoverByEmailSetCommand MapToCommand(this UserForgotPasswordRecoverByEmailSetRequest request)
    {
        var command = new UserForgotPasswordRecoverByEmailSetCommand
        {
            Email = request.Email,
            Proof = request.Proof,
        };
        return command;
    }
}