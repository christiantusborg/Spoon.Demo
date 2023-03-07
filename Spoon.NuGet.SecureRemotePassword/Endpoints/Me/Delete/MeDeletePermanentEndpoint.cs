// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable MemberCanBePrivate.Global

namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Me;

using System.Security.Claims;
using Application.Me.Delete.Permanent;
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
public static class MeDeletePermanentEndpoint
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapMeDeletePermanent(this IEndpointRouteBuilder app)
    {
        app.MapDelete(ApiMeEndpoints.Delete.Permanent.Endpoint, DeletePermanentAsync)
            .WithName(nameof(ApiMeEndpoints.Delete.Permanent))
            .Produces(204)
            .Produces<PermissionFailed<MeDeletePermanentRequest>>(403)
            .Produces(404)
            .Produces<Validationfailures>(406)
            .AddEndpointFilter<VerifyProofEndpointFilter>()
            .WithMetadata(new SwaggerOperationAttribute(ApiMeEndpoints.Delete.Permanent.Summary, ApiMeEndpoints.Delete.Permanent.Description))
            .AddEndpointFilter<VerifyProofEndpointFilter>()
            .AddEndpointFilter<VerifyServerProofEndpointFilter>()
            .RequireAuthorization();

        return app;
    }

    private static MeDeletePermanentCommand MapToCommand(Guid userId, Guid emailId)
    {
        var command = new MeDeletePermanentCommand
        {
            UserId = userId,
            EmailId = emailId,
        };
        return command;
    }

    internal static async Task<IResult> DeletePermanentAsync(Guid emailId,ClaimsPrincipal claimsPrincipal, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(emailId,claimsPrincipal.GetUserId());
        var commandResult = await sender.Send(command, cancellationToken);

        var response = commandResult.ToNoContent();
        return response;
    }
}