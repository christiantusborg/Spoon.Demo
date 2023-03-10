namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Administration;

using Application.Administration.AddUserEmail;
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
public static class AdministrationAddUserEmailEndpoint
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapAdministrationAddUserEmail(this IEndpointRouteBuilder app)
    {
        app.MapPut(ApiAdministrationEndpoints.AddUserEmail.Endpoint,
                async ([FromRoute] Guid userId, [FromBody] AdministrationAddUserEmailRequest request, ISender sender, CancellationToken cancellationToken) =>
                {
                    var command = request.MapToCommand(userId);
                    var commandResult = await sender.Send(command, cancellationToken);

                    var result = commandResult.ToNoContent();
                    return result;
                })
            .WithName(nameof(ApiAdministrationEndpoints.AddUserEmail))
            .Produces(201)
            .Produces<PermissionFailed<AdministrationAddUserEmailResult>>(403)
            .Produces<Validationfailures>(406)
            .WithMetadata(new SwaggerOperationAttribute(ApiAdministrationEndpoints.AddUserEmail.Summary, ApiAdministrationEndpoints.AddUserEmail.Description));

        return app;
    }

    private static AdministrationAddUserEmailCommand MapToCommand(this AdministrationAddUserEmailRequest request, Guid userId)
    {
        var command = new AdministrationAddUserEmailCommand
        {
            UserId = userId,
            Email = request.Email,
        };

        return command;
    }
}