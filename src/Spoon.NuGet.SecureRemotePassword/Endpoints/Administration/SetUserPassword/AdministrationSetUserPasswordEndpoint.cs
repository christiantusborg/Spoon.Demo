namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Administration.SetUserPassword;

using Application.Commands.Administration.SetUserPassword;
using Contracts;
using Core.Presentation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
/// </summary>
public class AdministrationSetUserPasswordEndpoint : IEndpointMarker
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapPut(ApiAdministrationEndpoints.SetUserPassword.Endpoint, SetUserPassword)
            .WithName(ApiAdministrationEndpoints.SetUserPassword.Name)
            .Produces(204)
            .Produces<PermissionFailed<AdministrationSetUserPasswordResult>>(403)
            .Produces<Validationfailures>(406)
            .WithMetadata(new SwaggerOperationAttribute(ApiAdministrationEndpoints.SetUserPassword.Summary, ApiAdministrationEndpoints.SetUserPassword.Description));

        return app;
    }

    private static AdministrationSetUserPasswordCommand MapToCommand(AdministrationSetUserPasswordRequest request)
    {
        var command = new AdministrationSetUserPasswordCommand
        {
            UserId = request.UserId,
            Salt = request.Salt,
            Verifier = request.Verifier,
        };

        return command;
    }

    private static async Task<IResult> SetUserPassword([FromRoute] Guid userId, [FromBody] AdministrationSetUserPasswordRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(request);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}