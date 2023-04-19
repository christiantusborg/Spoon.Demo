// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable MemberCanBePrivate.Global

namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Me.Email;

using System.Security.Claims;
using Application.Commands.Me.Email.Create;
using Contracts;
using Core.Presentation;
using EndpointFilters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;
using User;
using ClaimsPrincipalExtensions = Extensions.ClaimsPrincipalExtensions;

//public static class GetChallengeAuthentication
/// <summary>
///     Spoon.NuGet.SecureRemotePassword.Api
/// </summary>
public class MeEmailCreateEndpoint : IEndpointMarker
{
    /// <summary>
    ///     Map user add email endpoint.
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapPost(ApiMeEndpoints.Email.Create.Endpoint, MeEmailCreateAsync)
            .WithName(ApiMeEndpoints.Email.Create.Name)
            .WithTags(ApiMeEndpoints.Email.EmailTag)
            .Accepts<MeEmailCreateRequest>(ApiUserEndpoints.ContentType)
            .Produces(204)
            .Produces<PermissionFailed<MeEmailCreateCommand>>(403)
            .Produces<Validationfailures>(406)
            .Produces(409)
            .WithMetadata(new SwaggerOperationAttribute(ApiMeEndpoints.Email.Create.Summary, ApiMeEndpoints.Email.Create.Description))
            .AddEndpointFilter<VerifyProofEndpointFilter>()
            .AddEndpointFilter<VerifyServerProofEndpointFilter>()
            .RequireAuthorization();

        return app;
    }

    private static MeEmailCreateCommand MapToCommand(MeEmailCreateRequest request, Guid userId)
    {
        var command = new MeEmailCreateCommand
        {
            UserId = userId,
            Email = request.Email,
        };
        return command;
    }

    internal static async Task<IResult> MeEmailCreateAsync([FromBody] MeEmailCreateRequest request,
        [FromHeader(Name = "verifyProof")] string verifyProof,
        ClaimsPrincipal claimsPrincipal,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var command = MapToCommand(request, ClaimsPrincipalExtensions.GetUserId(claimsPrincipal));
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}