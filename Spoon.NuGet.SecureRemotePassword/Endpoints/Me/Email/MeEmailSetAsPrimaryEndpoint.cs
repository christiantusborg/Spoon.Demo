// ReSharper disable HeapView.ObjectAllocation

namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Me.Email;

using System.Security.Claims;
using Application.Me.Email.SetAsPrimaryEmail;
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
public static class MeEmailSetAsPrimaryEndpoint
{
    /// <summary>
    ///     Spoon.NuGet.SecureRemotePassword.Contracts
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapMeEmailSetAsPrimary(this IEndpointRouteBuilder app)
    {
        app.MapGet(ApiMeEndpoints.Email.SetAsPrimaryEmail.Endpoint, MeEmailSetAsPrimaryAsync)
            .WithName(nameof(ApiMeEndpoints.Email.SetAsPrimaryEmail))
            .WithTags(ApiMeEndpoints.Tag)
            .Accepts<MeEmailCreateRequest>(ApiUserEndpoints.ContentType)
            .Produces(204)
            .Produces<PermissionFailed<MeEmailCreateRequest>>(403)
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

    internal static async Task<IResult> MeEmailSetAsPrimaryAsync(Guid emailId, ClaimsPrincipal claimsPrincipal, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(emailId, claimsPrincipal.GetUserId());
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}