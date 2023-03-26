// ReSharper disable HeapView.ObjectAllocation

namespace Spoon.NuGet.SecureRemotePassword.Endpoints.User.ForgotPassword;

using Application.Users.UserForgotPasswordRecoverByRecoveryCodeSet;
using Contracts;
using EitherCore.Extensions;
using EndpointFilters;
using Mediator.PipelineBehaviors.Permission;
using Mediator.PipelineBehaviors.Validation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
///     Spoon.NuGet.SecureRemotePassword.Api
/// </summary>
public static class UserForgotPasswordSetByEmailEndpoint
{
    /// <summary>
    ///     Spoon.NuGet.SecureRemotePassword.Contracts
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapUserForgotPasswordSetByEmail(this IEndpointRouteBuilder app)
    {
        app.MapPost(ApiUserEndpoints.ForgotPassword.SetByEmail.Endpoint, UserForgotPasswordSetRecoverByEmail)
            .WithName(nameof(ApiUserEndpoints.ForgotPassword.SetByEmail.Name))
            .Produces(204)
            .Produces(404)
            .Produces<Validationfailures>(406)
            .Produces<PermissionFailed<ForgotPasswordRecoverByEmailAuthenticationResult>>(403)
            .AddEndpointFilter<VerifyProofEndpointFilter>()
            .WithMetadata(new SwaggerOperationAttribute(ApiUserEndpoints.ForgotPassword.SetByEmail.Summary, ApiUserEndpoints.ForgotPassword.SetByEmail.Description));

        return app;
    }

    private static UserForgotPasswordRecoverByRecoveryCodeSetCommand MapToCommand(this UserForgotPasswordSetByEmailRequest request)
    {
        var command = new UserForgotPasswordRecoverByRecoveryCodeSetCommand
        {
            UserId = request.UserId,
            Proof = request.Proof,
            Salt = request.Salt,
            Verifier = request.Verifier,
        };
        return command;
    }

    internal static async Task<IResult> UserForgotPasswordSetRecoverByEmail(this UserForgotPasswordSetByEmailRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = request.MapToCommand();
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}