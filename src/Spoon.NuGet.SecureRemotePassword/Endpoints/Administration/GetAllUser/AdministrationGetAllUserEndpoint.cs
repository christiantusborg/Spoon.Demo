namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Administration.GetAllUser;

using Application.Commands.Administration.GetAllUser;
using Contracts;
using Core.Presentation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
///     Class AdministrationGetAllUserEndpoint.
/// </summary>
public class AdministrationGetAllUserEndpoint : IEndpointMarker
{
    /// <summary>
    ///     Maps the specified application.
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapGet(ApiAdministrationEndpoints.GetAllUser.Endpoint, GetAllUser)
            .WithName(ApiAdministrationEndpoints.GetAllUser.Name)
            .Produces(204)
            .Produces<Validationfailures>(406)
            .Produces<PermissionFailed<GetAllAuthenticationAdministrationResult>>(403)
            .WithMetadata(new SwaggerOperationAttribute(ApiAdministrationEndpoints.GetAllUser.Summary, ApiAdministrationEndpoints.GetAllUser.Description));

        return app;
    }

    private static async Task<IResult> GetAllUser(ISender sender, CancellationToken cancellationToken)
    {
        var command = new AdministrationGetAllUserCommand();
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}