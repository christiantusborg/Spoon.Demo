// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable MemberCanBePrivate.Global

namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Me.Email;

using System.Security.Claims;
using Application.Commands.Me.Email.Get;
using Core.Presentation;
using EndpointFilters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;
using ClaimsPrincipalExtensions = Extensions.ClaimsPrincipalExtensions;

//public static class GetChallengeAuthentication
/// <summary>
///     Spoon.NuGet.SecureRemotePassword.Api
/// </summary>
public class MeEmailGetEndpoint : IEndpointMarker
{
    /// <summary>
    ///     Map user add email endpoint.
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapGet(ApiMeEndpoints.Email.Get.Endpoint, MeEmailGetAsync)
            .WithName(ApiMeEndpoints.Email.Get.Name)
            .WithTags(ApiMeEndpoints.Email.EmailTag)
            .Produces(204)
            .Produces<PermissionFailed<MeEmailGetCommand>>(403)
            .Produces<Validationfailures>(406)
            .Produces(409)
            .WithMetadata(new SwaggerOperationAttribute(ApiMeEndpoints.Email.Get.Summary, ApiMeEndpoints.Email.Get.Description))
            .AddEndpointFilter<VerifyProofEndpointFilter>()
            .AddEndpointFilter<VerifyServerProofEndpointFilter>()
            .RequireAuthorization();

        return app;
    }

    private static MeEmailGetCommand MapToCommand(Guid emailId, Guid userId)
    {
        var command = new MeEmailGetCommand
        {
            EmailId = emailId,
            UserId = userId,
        };
        return command;
    }

    internal static async Task<IResult> MeEmailGetAsync(Guid emailId,
        [FromHeader(Name = "verifyProof")] string verifyProof,
        ClaimsPrincipal claimsPrincipal,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var command = MapToCommand(emailId, ClaimsPrincipalExtensions.GetUserId(claimsPrincipal));
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}