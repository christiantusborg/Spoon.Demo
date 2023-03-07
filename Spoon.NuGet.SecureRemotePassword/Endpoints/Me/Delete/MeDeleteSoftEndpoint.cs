// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable MemberCanBePrivate.Global

namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Me;

using System.Security.Claims;
using Application.Me.Delete.Soft;
using Contracts;
using EitherCore.Extensions;
using EndpointFilters;
using Extensions;
using Mediator.PipelineBehaviors.Permission;
using Mediator.PipelineBehaviors.Validation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
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

    private static MeDeleteSoftCommand MapToCommand(Guid userId,Guid emailId)
    {
        var command = new MeDeleteSoftCommand
        {
            UserId = userId,
            EmailId = emailId,
        };
        return command;
    }

    internal static async Task<IResult> DeleteSoftAsync(Guid emailId, ClaimsPrincipal claimsPrincipal, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(claimsPrincipal.GetUserId(),emailId);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}