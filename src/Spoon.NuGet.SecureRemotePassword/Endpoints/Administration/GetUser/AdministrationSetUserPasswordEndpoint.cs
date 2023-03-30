namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Administration.GetUser;

using Application.Administration.GetUser;
using Core.Presentation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Spoon.NuGet.EitherCore.Extensions;
using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;
using Spoon.NuGet.Mediator.PipelineBehaviors.Validation;
using Spoon.NuGet.SecureRemotePassword.Application.Administration.SetUserPassword;
using Spoon.NuGet.SecureRemotePassword.Contracts;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
/// </summary>
public class AdministrationGetUserEndpoint : IEndpointMarker
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapPut(ApiAdministrationEndpoints.GetUser.Endpoint, SetUserPassword)
            .WithName(ApiAdministrationEndpoints.GetUser.Name)
            .Produces(204)
            .Produces<PermissionFailed<AdministrationSetUserPasswordResult>>(403)
            .Produces<Validationfailures>(406)
            .WithMetadata(new SwaggerOperationAttribute(ApiAdministrationEndpoints.GetUser.Summary, ApiAdministrationEndpoints.GetUser.Description));

        return app;
    }
    private static AdministrationGetUserCommand MapToCommand(Guid userId)
    {
        var command = new AdministrationGetUserCommand
        {
            UserId = userId,
    };

        return command;
    }
    
    private static async Task<IResult> SetUserPassword([FromRoute] Guid userId, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(userId);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }     

}