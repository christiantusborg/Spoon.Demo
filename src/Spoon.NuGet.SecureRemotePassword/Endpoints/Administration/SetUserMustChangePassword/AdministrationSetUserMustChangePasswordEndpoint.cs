namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Administration.SetUserMustChangePassword;

using Core.Presentation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Spoon.NuGet.EitherCore.Extensions;
using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;
using Spoon.NuGet.Mediator.PipelineBehaviors.Validation;
using Spoon.NuGet.SecureRemotePassword.Application.Administration.SetUserMustChangePassword;
using Spoon.NuGet.SecureRemotePassword.Contracts;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
/// </summary>
public class AdministrationSetUserMustChangePasswordEndpoint  : IEndpointMarker
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapGet(ApiAdministrationEndpoints.SetUserMustChangePassword.Endpoint, SetUserMustChangePassword)
            .WithName(ApiAdministrationEndpoints.SetUserMustChangePassword.Name)
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
    
    private static async Task<IResult> SetUserMustChangePassword([FromRoute] Guid userId,[FromRoute] bool value, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(userId, value);
        var commandResult =await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    } 
}