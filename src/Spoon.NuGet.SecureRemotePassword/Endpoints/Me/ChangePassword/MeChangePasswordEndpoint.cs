// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable MemberCanBePrivate.Global

namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Me.ChangePassword;

using System.Security.Claims;
using Application.Commands.Me.ChangePassword;
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
///     Spoon.NuGet.SecureRemotePassword.Api
/// </summary>
public class MeChangePasswordEndpoint : IEndpointMarker
{
    /// <summary>
    ///     Map User ChangePassword endpoint
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapPost(ApiMeEndpoints.ChangePassword.Create.Endpoint, ChangePasswordAsync)
            .WithName(ApiMeEndpoints.ChangePassword.Create.Name)
            .WithTags(ApiMeEndpoints.ChangePassword.PasswordTag)
            .Accepts<MeChangePasswordRequest>(ApiMeEndpoints.ContentType)
            .Produces(204)
            .Produces(403)
            .Produces<Validationfailures>(406)
            .Produces(409)
            .WithMetadata(new SwaggerOperationAttribute(ApiMeEndpoints.ChangePassword.Create.Summary, ApiMeEndpoints.ChangePassword.Create.Description))
            .AddEndpointFilter<VerifyProofEndpointFilter>()
            .AddEndpointFilter<VerifyServerProofEndpointFilter>()
            .RequireAuthorization();

        return app;
    }

    private static MeChangePasswordCommand MapToCommand(MeChangePasswordRequest request, Guid userId)
    {
        var command = new MeChangePasswordCommand
        {
            UserId = userId,
            Verifier = request.Verifier,
            Salt = request.Salt,
        };
        return command;
    }

    internal static async Task<IResult> ChangePasswordAsync([FromBody] MeChangePasswordRequest request, ClaimsPrincipal claimsPrincipal, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(request, ClaimsPrincipalExtensions.GetUserId(claimsPrincipal));
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}