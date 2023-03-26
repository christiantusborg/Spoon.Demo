namespace Spoon.NuGet.SecureRemotePassword.Endpoints.UserClaim;

using AddBulk;
using Microsoft.AspNetCore.Routing;
using RemoveBulk;
using RoleClaim.RemoveBulk;
using Spoon.NuGet.SecureRemotePassword.Endpoints.RoleClaim.AddBulk;

/// <summary>
/// </summary>
public static class UserClaimEndpointExtensions
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapUserClaimEndpoints(this IEndpointRouteBuilder app)
    {
        //AddBulk
        app.MapUserClaimAddBulk();
        
        //RemoveBulk
        app.MapUserClaimRemoveBulk();
        
        return app;
    }
}