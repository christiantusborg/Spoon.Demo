namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Administration;

using Application.Administration.GetAllUser;
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
public static class AdministrationGetAllUserEndpoint
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapAdministrationGetAllUser(this IEndpointRouteBuilder app)
    {
        app.MapGet(ApiAdministrationEndpoints.GetAllUser.Endpoint,  async (ISender sender, CancellationToken cancellationToken) =>
            {
                var command = new AdministrationGetAllUserCommand();
                var commandResult = await sender.Send(command, cancellationToken);

                var result = commandResult.ToNoContent();
                return result;
            })
            .WithName(nameof(ApiAdministrationEndpoints.GetAllUser))
            .Produces(204)
            .Produces<Validationfailures>(406)
            .Produces<PermissionFailed<GetAllAuthenticationAdministrationResult>>(403)
            .WithMetadata(new SwaggerOperationAttribute(ApiAdministrationEndpoints.GetAllUser.Summary, ApiAdministrationEndpoints.GetAllUser.Description));
        
        return app;
            

    }
}