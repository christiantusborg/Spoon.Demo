namespace Spoon.NuGet.SecureRemotePassword.Endpoints.RoleClaim;

using AddBulk;
using Microsoft.AspNetCore.Routing;
using RemoveBulk;
using Spoon.NuGet.SecureRemotePassword.Endpoints.Claim.GetAll;

/// <summary>
/// </summary>
public static class RoleClaimEndpointExtensions
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapRoleClaimEndpoints(this IEndpointRouteBuilder app)
    {
        //AddBulk
        app.MapRoleClaimAddBulk();
        
        //RemoveBulk
        app.MapRoleClaimRemoveBulk();
        
        return app;
    }
}