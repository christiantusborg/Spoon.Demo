// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable MemberCanBePrivate.Global

namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Me.RecoveryCode;

using Application.Me.UserGenerateRecoveryCode;
using Contracts;
using Core.Presentation;
using EitherCore.Extensions;
using EndpointFilters;
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
public class MeRecoveryCodeEndpoint : IEndpointMarker
{
    /// <summary>
    ///     Spoon.NuGet.SecureRemotePassword.Contracts
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapGet(ApiMeEndpoints.RecoveryCode.Get.Endpoint, MeRecoveryCodeAsync)
            .WithName(ApiMeEndpoints.RecoveryCode.Get.Name)
            .WithTags(ApiMeEndpoints.RecoveryCode.RecoveryCodeTag)
            .Produces(204)
            .Produces<PermissionFailed<UserGenerateRecoveryCodeCommand>>(403)
            .Produces(404)
            .Produces<Validationfailures>(406)
            .AddEndpointFilter<VerifyProofEndpointFilter>()
            .WithMetadata(new SwaggerOperationAttribute(ApiMeEndpoints.RecoveryCode.Get.Summary, ApiMeEndpoints.RecoveryCode.Get.Description))
            .AddEndpointFilter<VerifyProofEndpointFilter>()
            .AddEndpointFilter<VerifyServerProofEndpointFilter>()
            .RequireAuthorization();

        return app;
    }

    internal static async Task<IResult> MeRecoveryCodeAsync([FromHeader(Name = "verifyProof")] string verifyProof, ISender sender, CancellationToken cancellationToken)
    {
        var command = new UserGenerateRecoveryCodeCommand();
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToResult(typeof(UserGenerateRecoveryCodeResult));
        return result;
    }
}