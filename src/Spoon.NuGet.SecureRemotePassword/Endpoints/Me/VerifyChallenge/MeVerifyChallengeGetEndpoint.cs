// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable MemberCanBePrivate.Global

namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Me.VerifyChallenge;

using System.Security.Claims;
using Application.Commands.Me.VerifyChallenge;
using Core.Presentation;
using EndpointFilters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
///     Spoon.NuGet.SecureRemotePassword.Api
/// </summary>
public class MeVerifyChallengeGetEndpoint : IEndpointMarker
{
    /// <summary>
    ///     Map user add VerifyChallenge endpoint.
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapGet(ApiMeEndpoints.VerifyChallenge.Get.Endpoint, MeVerifyChallengeGetAsync)
            .WithName(ApiMeEndpoints.VerifyChallenge.Get.Name)
            .WithTags(ApiMeEndpoints.VerifyChallenge.VerifyChallengeTag)
            .Produces(204)
            .Produces<PermissionFailed<MeVerifyChallengeGetCommand>>(403)
            .Produces<Validationfailures>(406)
            .Produces(409)
            .WithMetadata(new SwaggerOperationAttribute(ApiMeEndpoints.VerifyChallenge.Get.Summary, ApiMeEndpoints.VerifyChallenge.Get.Description))
            .AddEndpointFilter<VerifyProofEndpointFilter>()
            .AddEndpointFilter<VerifyServerProofEndpointFilter>()
            .RequireAuthorization();

        return app;
    }

    private static MeVerifyChallengeGetCommand MapToCommand(Guid userId)
    {
        var command = new MeVerifyChallengeGetCommand
        {
            UserId = userId,
        };
        return command;
    }

    internal static async Task<IResult> MeVerifyChallengeGetAsync(ClaimsPrincipal claimsPrincipal, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(ClaimsPrincipalExtensions.GetUserId(claimsPrincipal));
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}