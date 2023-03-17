namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Administration;

using Application.Administration.SetUserMustChangePassword;
using EitherCore.Extensions;
using Extensions;
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
/// </summary>
public static class AdministrationSetUserMustChangePasswordEndpoint
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapAdministrationSetUserMustChangePassword(this IEndpointRouteBuilder app)
    {
        app.MapGet(ApiAdministrationEndpoints.SetUserMustChangePassword.Endpoint, async ([FromRoute] Guid userId,[FromRoute] bool value, ISender sender, CancellationToken cancellationToken) =>
            {
                var command = MapToCommand(userId, value);
                var commandResult =await sender.Send(command, cancellationToken);

                var result = commandResult.ToNoContent();
                return result;
            })
            .WithName(nameof(ApiAdministrationEndpoints.SetUserMustChangePassword))
            .Produces(204)
            .Produces<PermissionFailed<AdministrationSetUserMustChangePasswordResult>>(403)
            .Produces<Validationfailures>(406)
            .WithMetadata(new SwaggerOperationAttribute(ApiAdministrationEndpoints.SetUserMustChangePassword.Summary, ApiAdministrationEndpoints.SetUserMustChangePassword.Description));

        return app;
    }
    
    private static AdministrationSetUserMustChangePasswordCommand MapToCommand(Guid userId, bool value)
    {
        var command = new AdministrationSetUserMustChangePasswordCommand
        {
            UserId = userId,
            Value = value,
        };

        return command;
    }
}