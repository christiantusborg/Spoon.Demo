// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable MemberCanBePrivate.Global

namespace Spoon.NuGet.SecureRemotePassword.Endpoints.User;

using Application.User.ConfirmEmail;
using Contracts;
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

//public static class GetChallengeAuthentication
/// <summary>
///     Spoon.NuGet.SecureRemotePassword.Api
/// </summary>
public static class UserConfirmEmailEndpoint
{
    /// <summary>
    ///     Spoon.NuGet.SecureRemotePassword.Contracts
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapUserConfirmEmail(this IEndpointRouteBuilder app)
    {
        app.MapPost(ApiUserEndpoints.ConfirmEmail.Endpoint, ConfirmEmail)
            .WithName(nameof(ApiUserEndpoints.ConfirmEmail))
            .WithTags(ApiUserEndpoints.Tag)
            .Produces(204)
            .Produces<Validationfailures>(406)
            .Produces<PermissionFailed<UserConfirmEmailCommandResult>>(403)
            .WithMetadata(new SwaggerOperationAttribute(ApiUserEndpoints.ConfirmEmail.Summary, ApiUserEndpoints.ConfirmEmail.Description))
            .AddEndpointFilter<VerifyProofEndpointFilter>()
            .AddEndpointFilter<VerifyServerProofEndpointFilter>()
            .RequireAuthorization();
            

        return app;
    }

    private static UserConfirmEmailCommand MapToCommand(this UserConfirmEmailRequest request)
    {
        var command = new UserConfirmEmailCommand
        {
            ConfirmCode = request.ConfirmCode,
        };
        return command;
    }

    internal static async Task<IResult> ConfirmEmail([FromBody] UserConfirmEmailRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = request.MapToCommand();

        await sender.Send(command, cancellationToken);

        return Results.NoContent();
    }
}