namespace Spoon.NuGet.SecureRemotePassword.Endpoints.User;

using Application.Me.UserGenerateRecoveryCode;
using Contracts;
using EitherCore.Extensions;
using EndpointFilters;
using Me;
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
public static class MeRecoveryCodeEndpoint
{
    /// <summary>
    ///     Spoon.NuGet.SecureRemotePassword.Contracts
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapMeRecoveryCode(this IEndpointRouteBuilder app)
    {
        app.MapGet(ApiMeEndpoints.RecoveryCode.Endpoint, MeRecoveryCodeAsync)
            .WithName(nameof(ApiMeEndpoints.RecoveryCode))
            .Produces(204)
            .Produces<PermissionFailed<UserDeleteSoftRequest>>(403)
            .Produces(404)
            .Produces<Validationfailures>(406)
            .AddEndpointFilter<VerifyProofEndpointFilter>()
            .WithMetadata(new SwaggerOperationAttribute(ApiMeEndpoints.RecoveryCode.Summary, ApiMeEndpoints.RecoveryCode.Description))
            .AddEndpointFilter<VerifyProofEndpointFilter>()
            .AddEndpointFilter<VerifyServerProofEndpointFilter>()
            .RequireAuthorization();

        return app;
    }

    internal static async Task<IResult> MeRecoveryCodeAsync(ISender sender, CancellationToken cancellationToken)
    {
        var command = new UserGenerateRecoveryCodeCommand();
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToResult(typeof(UserGenerateRecoveryCodeResult));
        return result;
    }
}