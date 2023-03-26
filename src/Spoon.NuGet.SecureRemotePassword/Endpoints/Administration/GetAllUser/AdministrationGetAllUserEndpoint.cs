namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Administration.GetAllUser;

using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Spoon.NuGet.EitherCore.Extensions;
using Spoon.NuGet.Mediator.PipelineBehaviors.Permission;
using Spoon.NuGet.Mediator.PipelineBehaviors.Validation;
using Spoon.NuGet.SecureRemotePassword.Application.Administration.GetAllUser;
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