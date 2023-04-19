// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable MemberCanBePrivate.Global

namespace Spoon.NuGet.SecureRemotePassword.Endpoints.User.ForgotPassword;

using Application.Commands.Users.UserForgotPasswordRecoverByEmailInit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
///     Spoon.NuGet.SecureRemotePassword.Api
/// </summary>
public class UserForgotPasswordInitByEmailEndpoint //: IEndpointMarker
{
    /// <summary>
    ///     Spoon.NuGet.SecureRemotePassword.Contracts
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapGet(ApiUserEndpoints.ForgotPassword.InitByEmail.Endpoint, ForgotPasswordInitByEmail)
            .WithName(nameof(ApiUserEndpoints.ForgotPassword.InitByEmail.Name))
            .WithTags(ApiUserEndpoints.ForgotPassword.ForgotPasswordTag)
            .Produces(204)
            .Produces<Validationfailures>(406)
            .Produces<PermissionFailed<UserForgotPasswordRecoverByEmailInitCommand>>(403)
            .WithMetadata(new SwaggerOperationAttribute(ApiUserEndpoints.Email.Confirm.Summary, ApiUserEndpoints.Email.Confirm.Description));
        return app;
    }

    private static UserForgotPasswordRecoverByEmailInitCommand MapToCommand(string email)
    {
        var command = new UserForgotPasswordRecoverByEmailInitCommand
        {
            Email = email,
        };
        return command;
    }

    internal static async Task<IResult> ForgotPasswordInitByEmail(string email, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(email);

        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}