// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable MemberCanBePrivate.Global

namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Me.Delete;

using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Spoon.NuGet.EitherCore.Extensions;
using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;
using Spoon.NuGet.Mediator.PipelineBehaviors.Validation;
using Spoon.NuGet.SecureRemotePassword.Application.Me.Delete.Soft;
using Spoon.NuGet.SecureRemotePassword.Contracts;
using Spoon.NuGet.SecureRemotePassword.EndpointFilters;
using Spoon.NuGet.SecureRemotePassword.Extensions;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
/// </summary>
public static class MeDeleteSoftEndpoint
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapMeDeleteSoft(this IEndpointRouteBuilder app)
    {
        app.MapDelete(ApiMeEndpoints.Delete.Soft.Endpoint, DeleteSoftAsync)
            .WithName(nameof(ApiMeEndpoints.Delete.Soft))
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
        var command = MapToCommand(claimsPrincipal.GetUserId());
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}