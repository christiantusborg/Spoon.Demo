// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable MemberCanBePrivate.Global

namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Me.Email;

using System.Security.Claims;
using Application.Me.Email.Get;
using Application.Me.Email.GetAll;
using Core.Presentation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Spoon.NuGet.EitherCore.Extensions;
using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;
using Spoon.NuGet.Mediator.PipelineBehaviors.Validation;
using Spoon.NuGet.SecureRemotePassword.Contracts;
using Spoon.NuGet.SecureRemotePassword.EndpointFilters;
using Swashbuckle.AspNetCore.Annotations;
using ClaimsPrincipalExtensions = Extensions.ClaimsPrincipalExtensions;

//public static class GetChallengeAuthentication
/// <summary>
///     Spoon.NuGet.SecureRemotePassword.Api
/// </summary>
public class MeEmailGetAllEndpoint : IEndpointMarker
{
    /// <summary>
    ///     Map user add email endpoint.
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapGet(ApiMeEndpoints.Email.GetAll.Endpoint, MeEmailCreateAsync)
            .WithName(ApiMeEndpoints.Email.GetAll.Name)
            .WithTags(ApiMeEndpoints.Email.EmailTag)
            .Produces(204)
            .Produces<PermissionFailed<MeEmailGetCommand>>(403)
            .Produces<Validationfailures>(406)
            .Produces(409)
            .WithMetadata(new SwaggerOperationAttribute(ApiMeEndpoints.Email.GetAll.Summary, ApiMeEndpoints.Email.GetAll.Description))
            .AddEndpointFilter<VerifyProofEndpointFilter>()
            .AddEndpointFilter<VerifyServerProofEndpointFilter>()
            .RequireAuthorization();

        return app;
    }

    private static MeEmailGetCommand MapToCommand(Guid userId)
    {
        var command = new MeEmailGetCommand
        {
            UserId = userId,
        };
        return command;
    }
   
    internal static async Task<IResult> MeEmailCreateAsync([FromHeader(Name = "verifyProof")] string verifyProof, ClaimsPrincipal claimsPrincipal, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(ClaimsPrincipalExtensions.GetUserId(claimsPrincipal));
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}