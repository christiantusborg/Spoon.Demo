namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Role.Create;

using Application.Commands.Roles.Create;
using Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
/// </summary>
public class RoleCreateEndpoint //: IEndpointMarker
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapPost(ApiRoleEndpoints.Create.Endpoint, CreateUser)
            .WithName(ApiRoleEndpoints.Create.Name)
            .Produces(204)
            .Produces<PermissionFailed<AdministrationCreateUserResult>>(403)
            .Produces<Validationfailures>(406)
            .WithMetadata(new SwaggerOperationAttribute(ApiRoleEndpoints.Create.Summary, ApiRoleEndpoints.Create.Description));

        return app;
    }

    private static RoleCreateCommand MapToCommand(RoleCreateRequest request)
    {
        var command = new RoleCreateCommand
        {
            Name = request.Name,
        };
        return command;
    }

    private static async Task<IResult> CreateUser([FromBody] RoleCreateRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(request);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}