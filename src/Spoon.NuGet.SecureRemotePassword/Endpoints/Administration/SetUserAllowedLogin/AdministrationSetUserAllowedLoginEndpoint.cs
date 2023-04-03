namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Administration.SetUserAllowedLogin;

using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Spoon.NuGet.Core.Presentation;
using Spoon.NuGet.EitherCore.Extensions;
using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;
using Spoon.NuGet.Mediator.PipelineBehaviors.Validation;
using Spoon.NuGet.SecureRemotePassword.Application.Administration.SetUserAllowedLogin;
using Spoon.NuGet.SecureRemotePassword.Contracts;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
/// 
/// </summary>
public class AdministrationSetUserAllowedLoginEndpoint : IEndpointMarker
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapGet(ApiAdministrationEndpoints.SetUserAllowedLogin.Endpoint, SetUserAllowedLogin)
            .WithName(ApiAdministrationEndpoints.SetUserAllowedLogin.Name)
            .Produces(204)
            .Produces<Validationfailures>(406)
            .Produces<PermissionFailed<AdministrationSetUserAllowedLoginResult>>(403)
            .WithMetadata(new SwaggerOperationAttribute(ApiAdministrationEndpoints.SetUserAllowedLogin.Summary, ApiAdministrationEndpoints.SetUserAllowedLogin.Description));
        
        return app;
            

    }
    
    private static AdministrationSetUserAllowedLoginCommand MapToCommand(Guid userId, bool value)
    {
        var command = new AdministrationSetUserAllowedLoginCommand
        {
            UserId = userId,
            Value = value,
        };

        return command;
    }
    
    private static async Task<IResult> SetUserAllowedLogin([FromRoute] Guid userId,[FromRoute] bool value, ISender sender, CancellationToken cancellationToken)
    {
        var command = MapToCommand(userId, value);
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }  
}