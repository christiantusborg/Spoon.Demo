namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Claim.GetAll;

using Administration;
using Application.Claim.GetAll;
using Core.Presentation;
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
public class ClaimGetAllEndpoint  : IEndpointMarker
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public IEndpointRouteBuilder Map(IEndpointRouteBuilder app)
    {
        app.MapGet(ApiClaimEndpoints.GetAll.Endpoint, GetAll)
            .WithName(ApiClaimEndpoints.GetAll.Name)
            .Produces(204)
            .Produces<Validationfailures>(406)
            .Produces<PermissionFailed<GetAllAuthenticationAdministrationResult>>(403)
            .WithMetadata(new SwaggerOperationAttribute(ApiClaimEndpoints.GetAll.Summary, ApiClaimEndpoints.GetAll.Description));
        
        return app;
    }
    
    private static async Task<IResult> GetAll(ISender sender, CancellationToken cancellationToken)
    {
        var command = new ClaimGetAllCommand();
        var commandResult = await sender.Send(command, cancellationToken);

        var result = commandResult.ToNoContent();
        return result;
    }
}