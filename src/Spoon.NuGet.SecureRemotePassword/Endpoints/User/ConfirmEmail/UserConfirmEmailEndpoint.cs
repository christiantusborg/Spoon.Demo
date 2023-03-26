// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable MemberCanBePrivate.Global

namespace Spoon.NuGet.SecureRemotePassword.Endpoints.User.ConfirmEmail;

using Application.Users.ConfirmEmail;
using EitherCore.Extensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;
using Spoon.NuGet.Mediator.PipelineBehaviors.Validation;
using Spoon.NuGet.SecureRemotePassword.Contracts;
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
        app.MapPost(ApiUserEndpoints.Email.Confirm.Endpoint, ConfirmEmail)
            .WithName(nameof(ApiUserEndpoints.Email.Confirm.Name))
            .WithTags(ApiUserEndpoints.Email.EmailTag)
            .Produces(204)
            .Produces<Validationfailures>(406)
            .Produces<PermissionFailed<UserConfirmEmailCommandResult>>(403)
            .WithMetadata(new SwaggerOperationAttribute(ApiUserEndpoints.Email.Confirm.Summary, ApiUserEndpoints.Email.Confirm.Description));


        return app;
    }

    private static UserConfirmEmailCommand MapToCommand(this UserConfirmEmailRequest request)
    {
        var command = new UserConfirmEmailCommand
        {
            ConfirmCode = request.ConfirmCode,
            EmailId = request.EmailId,
        };
        return command;
    }

    internal static async Task<IResult> ConfirmEmail([FromBody] UserConfirmEmailRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = request.MapToCommand();

        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}