// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable MemberCanBePrivate.Global

namespace Spoon.NuGet.SecureRemotePassword.Endpoints.User.ConfirmEmail;

using Application.Commands.Users.ConfirmEmail;
using Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
///     Spoon.NuGet.SecureRemotePassword.Api
/// </summary>
public class UserConfirmEmailEndpoint // : IEndpointMarker
{
    /// <summary>
    ///     Spoon.NuGet.SecureRemotePassword.Contracts
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapPost(ApiUserEndpoints.Email.Confirm.Endpoint, this.ConfirmEmail)
            .WithName(nameof(ApiUserEndpoints.Email.Confirm.Name))
            .WithTags(ApiUserEndpoints.Email.EmailTag)
            .Produces(204)
            .Produces<Validationfailures>(406)
            .Produces<PermissionFailed<UserConfirmEmailCommandResult>>(403)
            .WithMetadata(new SwaggerOperationAttribute(ApiUserEndpoints.Email.Confirm.Summary, ApiUserEndpoints.Email.Confirm.Description));


        return app;
    }

    private UserConfirmEmailCommand MapToCommand(UserConfirmEmailRequest request)
    {
        var command = new UserConfirmEmailCommand
        {
            ConfirmCode = request.ConfirmCode,
            EmailId = request.EmailId,
        };
        return command;
    }

    internal async Task<IResult> ConfirmEmail([FromBody] UserConfirmEmailRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = this.MapToCommand(request);

        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}