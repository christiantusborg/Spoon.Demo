namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Claim.GetAll;

using Application.Commands.Claim.GetAll;
using Contracts;
using Core.Presentation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;

//public static class GetChallengeAuthentication
/// <summary>
/// </summary>
public class ClaimGetAllEndpoint : IEndpointMarker
{
    /// <summary>
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