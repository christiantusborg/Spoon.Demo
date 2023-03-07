// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable MemberCanBePrivate.Global

namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Me;

using System.Security.Claims;
using Application.Me.ChangePassword;
using Contracts;
using EitherCore.Extensions;
using EndpointFilters;
using Extensions;
using Mediator.PipelineBehaviors.Permission;
using Mediator.PipelineBehaviors.Validation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;
using User.Extensions;

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
        app.MapPost(ApiMeEndpoints.ChangePassword.Endpoint, ChangePasswordAsync)
            .WithName(nameof(ApiMeEndpoints.ChangePassword))
            .WithTags(ApiUserEndpoints.Tag)
            .Accepts<MeEmailCreateRequest>(ApiUserEndpoints.ContentType)
            .Produces(204)
            .Produces(403)
            .Produces<Validationfailures>(406)
            .Produces(409)
            .WithMetadata(new SwaggerOperationAttribute(ApiMeEndpoints.ChangePassword.Summary, ApiMeEndpoints.ChangePassword.Description))
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

    internal static async Task<IResult> ChangePasswordAsync([FromBody] MeChangePasswordRequest request, ClaimsPrincipal claimsPrincipal, ISender sender, CancellationToken cancellationToken)
    {
        var command = request.MapToCommand(claimsPrincipal.GetUserId());
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}