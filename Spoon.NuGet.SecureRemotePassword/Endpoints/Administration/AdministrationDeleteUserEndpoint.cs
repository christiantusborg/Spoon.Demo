namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Administration;

using Application.Administration.DeleteUser;
using EitherCore.Extensions;
using Extensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.AspNetCore.Routing;
using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;
using Spoon.NuGet.Mediator.PipelineBehaviors.Validation;
using Spoon.NuGet.SecureRemotePassword.Contracts;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
/// 
/// </summary>
public static class AdministrationDeleteUserEndpoint
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapAdministrationDeleteUser(this IEndpointRouteBuilder app)
    {
        app.MapDelete(ApiAdministrationEndpoints.DeleteUserSoft.Endpoint,  async ([FromRoute] Guid userId,ISender sender, CancellationToken cancellationToken) =>
            {
                var command = MapToCommand(userId);
                var commandResult = await sender.Send(command, cancellationToken);

                var result = commandResult.ToNoContent();
                return result;
            })
            .WithName(nameof(ApiAdministrationEndpoints.DeleteUserSoft))
            .Produces(204)
            .Produces<Validationfailures>(406)
            .Produces<PermissionFailed<AdministrationDeleteUserResult>>(403)
            .WithMetadata(new SwaggerOperationAttribute(ApiAdministrationEndpoints.DeleteUserSoft.Summary, ApiAdministrationEndpoints.DeleteUserSoft.Description));
        
        return app;
    }
    
    private static AdministrationDeleteUserCommand MapToCommand(Guid userId)
    {
        var command = new AdministrationDeleteUserCommand
        {
            UserId = userId,
        };

        return command;
    }
}