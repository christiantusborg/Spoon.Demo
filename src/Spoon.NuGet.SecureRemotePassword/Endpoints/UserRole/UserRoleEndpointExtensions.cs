namespace Spoon.NuGet.SecureRemotePassword.Endpoints.UserRole;

using AddBulk;
using Microsoft.AspNetCore.Routing;
using RemoveBulk;

/// <summary>
/// </summary>
public static class UserRoleEndpointExtensions
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapUserRoleEndpoints(this IEndpointRouteBuilder app)
    {
        //AddBulk
        app.MapUserRoleAddBulk();
        
        //RemoveBulk
        app.MapUserRoleRemoveBulk();
        
        return app;
    }
}