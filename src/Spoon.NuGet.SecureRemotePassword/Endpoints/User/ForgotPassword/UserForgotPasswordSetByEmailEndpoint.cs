// ReSharper disable HeapView.ObjectAllocation

namespace Spoon.NuGet.SecureRemotePassword.Endpoints.User.ForgotPassword;

using Application.Users.UserForgotPasswordRecoverByRecoveryCodeSet;
using Contracts;
using Core.Presentation;
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
public class UserForgotPasswordSetByEmailEndpoint // : IEndpointMarker
{
    /// <summary>
    ///     Spoon.NuGet.SecureRemotePassword.Contracts
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
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

    private UserForgotPasswordRecoverByRecoveryCodeSetCommand MapToCommand(UserForgotPasswordSetByEmailRequest request)
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

    internal async Task<IResult> UserForgotPasswordSetRecoverByEmail(UserForgotPasswordSetByEmailRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(request);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}