// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable MemberCanBePrivate.Global

namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Me.Email;

using System.Security.Claims;
using Application.Me.Email.Create;
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
using Spoon.NuGet.SecureRemotePassword.Endpoints.User.Extensions;
using Spoon.NuGet.SecureRemotePassword.Extensions;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
///     Spoon.NuGet.SecureRemotePassword.Api
/// </summary>
public static class MeEmailCreateEndpoint
{
    /// <summary>
    ///     Map user add email endpoint.
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapMeEmailCreate(this IEndpointRouteBuilder app)
    {
        app.MapPost(ApiMeEndpoints.Email.Create.Endpoint, MeEmailCreateAsync)
            .WithName(nameof(ApiMeEndpoints.Email.Create))
            .WithTags(ApiMeEndpoints.Tag)
            .Accepts<MeEmailCreateRequest>(ApiUserEndpoints.ContentType)
            .Produces(204)
            .Produces<PermissionFailed<MeEmailCreateRequest>>(403)
            .Produces<Validationfailures>(406)
            .Produces(409)
            .WithMetadata(new SwaggerOperationAttribute(ApiMeEndpoints.Email.Create.Summary, ApiMeEndpoints.Email.Create.Description))
            .AddEndpointFilter<VerifyProofEndpointFilter>()
            .AddEndpointFilter<VerifyServerProofEndpointFilter>()
            .RequireAuthorization();

        return app;
    }

    private static MeEmailCreateEmailCommand MapToCommand(this MeEmailCreateRequest request, Guid userId)
    {
        var command = new MeEmailCreateEmailCommand
        {
            UserId = userId,
            Email = request.Email,
        };
        return command;
    }
   
    internal static async Task<IResult> MeEmailCreateAsync([FromBody] MeEmailCreateRequest request, ClaimsPrincipal claimsPrincipal, ISender sender, CancellationToken cancellationToken)
    {
        var command = request.MapToCommand(claimsPrincipal.GetUserId());
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}