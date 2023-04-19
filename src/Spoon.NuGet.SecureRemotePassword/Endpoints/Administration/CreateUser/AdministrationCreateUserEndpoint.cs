namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Administration.CreateUser;

using Application.Commands.Administration.CreateUser;
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
public class AdministrationCreateUserEndpoint : IEndpointMarker
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapPost(ApiAdministrationEndpoints.CreateUser.Endpoint, CreateUser)
            .WithName(ApiAdministrationEndpoints.CreateUser.Name)
            .Produces(204)
            .Produces<PermissionFailed<AdministrationCreateUserResult>>(403)
            .Produces<Validationfailures>(406)
            .WithMetadata(new SwaggerOperationAttribute(ApiAdministrationEndpoints.CreateUser.Summary, ApiAdministrationEndpoints.CreateUser.Description));

        return app;
    }

    /// <summary>
    ///     Maps to command.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public static AdministrationCreateUserCommand MapToCommand(AdministrationCreateUserRequest request)
    {
        var command = new AdministrationCreateUserCommand
        {
            UsernameHash = request.UsernameHash,
            Salt = request.Salt,
            Verifier = request.Verifier,
            Email = request.Email,
        };
        return command;
    }

    /// <summary>
    ///     Creates the user.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="sender"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private static async Task<IResult> CreateUser([FromBody] AdministrationCreateUserRequest request, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(request);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}