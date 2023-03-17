namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Administration;

using Application.Administration.DeleteUserPermanent;
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
public static class AdministrationDeleteUserPermanentEndpoint
{
    /// <summary>
    /// 
    /// </summary>
    public const string Name = "DeletePermanentAuthenticationAdministration";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapAdministrationDeleteUserPermanent(this IEndpointRouteBuilder app)
    {
        app.MapDelete(ApiAdministrationEndpoints.DeleteUserPermanent.Endpoint,  async ([FromRoute] Guid userId, ISender sender, CancellationToken cancellationToken) =>
            {
                var command = MapToCommand(userId);
                var commandResult = await sender.Send(command, cancellationToken);

                var result = commandResult.ToNoContent();
                return result;

            })
            .WithName(nameof(ApiAdministrationEndpoints.DeleteUserPermanent))
            .Produces(204)
            .Produces<Validationfailures>(406)
            .Produces<PermissionFailed<AdministrationDeleteUserPermanentResult>>(403)
            .WithMetadata(new SwaggerOperationAttribute(ApiAdministrationEndpoints.DeleteUserPermanent.Summary, ApiAdministrationEndpoints.DeleteUserPermanent.Description));
        
        return app;
    }

private static AdministrationDeleteUserPermanentCommand MapToCommand(Guid userId)
{
    var command = new AdministrationDeleteUserPermanentCommand
    {
        UserId = userId,
    };

    return command;
}
}