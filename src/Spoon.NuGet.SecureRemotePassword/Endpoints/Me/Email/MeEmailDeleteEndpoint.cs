﻿// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable MemberCanBePrivate.Global

namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Me.Email;

using System.Security.Claims;
using Application.Commands.Me.Email.Delete;
using Core.Presentation;
using EndpointFilters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
///     Spoon.NuGet.SecureRemotePassword.Api
/// </summary>
public class MeEmailDeleteEndpoint : IEndpointMarker
{
    /// <summary>
    ///     Spoon.NuGet.SecureRemotePassword.Contracts
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapDelete(ApiMeEndpoints.Email.Delete.Endpoint, MeEmailDeleteAsync)
            .WithName(ApiMeEndpoints.Email.Delete.Name)
            .WithTags(ApiMeEndpoints.Email.EmailTag)
            .Produces(204)
            .Produces<PermissionFailed<MeEmailDeleteCommand>>(403)
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

    internal static async Task<IResult> MeEmailDeleteAsync(Guid emailId,
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