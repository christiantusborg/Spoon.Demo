// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable MemberCanBePrivate.Global

namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Me.Email;

using System.Security.Claims;
using Application.Me.Email.Delete;
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
using User.Extensions;

//public static class GetChallengeAuthentication
/// <summary>
///     Spoon.NuGet.SecureRemotePassword.Api
/// </summary>
public static class MeEmailDeleteEndpoint
{
    /// <summary>
    ///     Spoon.NuGet.SecureRemotePassword.Contracts
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapMeEmailDelete(this IEndpointRouteBuilder app)
    {
        app.MapDelete(ApiMeEndpoints.Email.Delete.Endpoint, MeEmailDeleteAsync)
            .WithName(nameof(ApiMeEndpoints.Email.Delete))
            .WithTags(ApiMeEndpoints.Tag)
            .Accepts<MeEmailCreateRequest>(ApiUserEndpoints.ContentType)
            .Produces(204)
            .Produces<PermissionFailed<MeEmailCreateRequest>>(403)
            .Produces<Validationfailures>(406)
            .Produces(409)
            .WithMetadata(new SwaggerOperationAttribute(ApiMeEndpoints.Email.Delete.Summary, ApiMeEndpoints.Email.Delete.Description))
            .AddEndpointFilter<VerifyProofEndpointFilter>()
            .AddEndpointFilter<VerifyServerProofEndpointFilter>()
            .RequireAuthorization();

        return app;
    }

    private static MeEmailDeleteCommand MapToCommand(Guid emailId, Guid userId)
    {
        var command = new MeEmailDeleteCommand
        {
            UserId = userId,
            EmailId = emailId,
        };
        return command;
    }

    internal static async Task<IResult> MeEmailDeleteAsync(Guid emailId, ClaimsPrincipal claimsPrincipal, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(emailId, claimsPrincipal.GetUserId());

        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}