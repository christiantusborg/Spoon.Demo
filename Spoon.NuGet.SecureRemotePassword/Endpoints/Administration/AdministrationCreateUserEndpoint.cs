namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Administration;

using Application.Administration.CreateUser;
using Contracts;
using EitherCore.Extensions;
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
/// </summary>
public static class AdministrationCreateUserEndpoint
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapAdministrationCreateUser(this IEndpointRouteBuilder app)
    {
        app.MapPost(ApiAdministrationEndpoints.CreateUser.Endpoint, async ([FromBody] AdministrationCreateUserRequest request, ISender sender, CancellationToken cancellationToken) =>
            {
                var command = request.MapToCommand();
                var commandResult = await sender.Send(command, cancellationToken);

                var result = commandResult.ToNoContent();
                return result;
            })
            .WithName(nameof(ApiAdministrationEndpoints.CreateUser))
            .Produces(204)
            .Produces<PermissionFailed<AdministrationCreateUserResult>>(403)
            .Produces<Validationfailures>(406)
            .WithMetadata(new SwaggerOperationAttribute(ApiAdministrationEndpoints.CreateUser.Summary, ApiAdministrationEndpoints.CreateUser.Description));

        return app;
    }

    private static AdministrationCreateUserCommand MapToCommand(this AdministrationCreateUserRequest request)
    {
        var command = new AdministrationCreateUserCommand
        {
            Email = request.Email,
            Salt = request.Salt,
            Verifier = request.Verifier,
        };
        return command;
    }
}