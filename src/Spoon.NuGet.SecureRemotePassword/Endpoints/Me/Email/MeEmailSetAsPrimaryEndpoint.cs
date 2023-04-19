// ReSharper disable HeapView.ObjectAllocation

namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Me.Email;

using System.Security.Claims;
using Application.Commands.Me.Email.SetAsPrimaryEmail;
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
public class MeEmailSetAsPrimaryEndpoint : IEndpointMarker
{
    /// <summary>
    ///     Spoon.NuGet.SecureRemotePassword.Contracts
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapGet(ApiMeEndpoints.Email.SetAsPrimaryEmail.Endpoint, MeEmailSetAsPrimaryAsync)
            .WithName(ApiMeEndpoints.Email.SetAsPrimaryEmail.Name)
            .WithTags(ApiMeEndpoints.Email.EmailTag)
            .Produces(204)
            .Produces<PermissionFailed<MeEmailSetAsPrimaryCommand>>(403)
            .Produces<Validationfailures>(406)
            .Produces(409)
            .WithMetadata(new SwaggerOperationAttribute(ApiMeEndpoints.Email.SetAsPrimaryEmail.Summary, ApiMeEndpoints.Email.SetAsPrimaryEmail.Description))
            .AddEndpointFilter<VerifyProofEndpointFilter>()
            .AddEndpointFilter<VerifyServerProofEndpointFilter>()
            .RequireAuthorization();
        ;

        return app;
    }

    private static MeEmailSetAsPrimaryCommand MapToCommand(Guid emailId, Guid userId)
    {
        var command = new MeEmailSetAsPrimaryCommand
        {
            UserId = userId,
            EmailId = emailId,
        };
        return command;
    }

    internal static async Task<IResult> MeEmailSetAsPrimaryAsync(Guid emailId,
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