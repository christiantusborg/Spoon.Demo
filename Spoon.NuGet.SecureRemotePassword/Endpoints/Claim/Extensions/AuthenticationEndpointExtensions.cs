namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Claim.Extensions;

using Microsoft.AspNetCore.Routing;

/// <summary>
/// 
/// </summary>
public static class ClaimEndpointExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapClaimEndpoints(this IEndpointRouteBuilder app)
    {
        //app.MapCreateAuthentication();
        
        return app;
    }
}