// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable MemberCanBePrivate.Global

namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Me.ChangePassword;

using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Spoon.NuGet.EitherCore.Extensions;
using Spoon.NuGet.Mediator.PipelineBehaviors.Validation;
using Spoon.NuGet.SecureRemotePassword.Application.Me.ChangePassword;
using Spoon.NuGet.SecureRemotePassword.Contracts;
using Spoon.NuGet.SecureRemotePassword.EndpointFilters;
using Spoon.NuGet.SecureRemotePassword.Extensions;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
///     Spoon.NuGet.SecureRemotePassword.Api
/// </summary>
public static class MeChangePasswordEndpoint
{
    /// <summary>
    ///     Map User ChangePassword endpoint
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapMeChangePassword(this IEndpointRouteBuilder app)
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

    private static MeChangePasswordCommand MapToCommand(this MeChangePasswordRequest request, Guid userId)
    {
        var command = new MeChangePasswordCommand
        {
            UserId = userId,
            Verifier = request.Verifier,
            Salt = request.Salt,
        };
        return command;
    }

    internal static async Task<IResult> ChangePasswordAsync([FromBody] MeChangePasswordRequest request, [FromHeader(Name = "verifyProof")] string verifyProof, ClaimsPrincipal claimsPrincipal, ISender sender, CancellationToken cancellationToken)
    {
        var command = request.MapToCommand(claimsPrincipal.GetUserId());
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}