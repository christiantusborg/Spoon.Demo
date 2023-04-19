// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable MemberCanBePrivate.Global

namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Me.Delete;

using System.Security.Claims;
using Application.Commands.Me.Delete.Soft;
using Contracts;
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
/// </summary>
public class MeDeleteSoftEndpoint : IEndpointMarker
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapDelete(ApiMeEndpoints.Delete.Soft.Endpoint, DeleteSoftAsync)
            .WithName(ApiMeEndpoints.Delete.Soft.Name)
            .WithTags(ApiMeEndpoints.Tag)
            .Produces(204)
            .Produces<PermissionFailed<UserDeleteSoftRequest>>(403)
            .Produces(404)
            .Produces<Validationfailures>(406)
            .AddEndpointFilter<VerifyProofEndpointFilter>()
            .WithMetadata(new SwaggerOperationAttribute(ApiMeEndpoints.Delete.Soft.Summary, ApiMeEndpoints.Delete.Soft.Description))
            .AddEndpointFilter<VerifyProofEndpointFilter>()
            .AddEndpointFilter<VerifyServerProofEndpointFilter>()
            .RequireAuthorization();

        return app;
    }

    private static MeDeleteSoftCommand MapToCommand(Guid userId)
    {
        var command = new MeDeleteSoftCommand
        {
            UserId = userId,
        };
        return command;
    }

    internal static async Task<IResult> DeleteSoftAsync([FromHeader(Name = "verifyProof")] string verifyProof, ClaimsPrincipal claimsPrincipal, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(ClaimsPrincipalExtensions.GetUserId(claimsPrincipal));
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}