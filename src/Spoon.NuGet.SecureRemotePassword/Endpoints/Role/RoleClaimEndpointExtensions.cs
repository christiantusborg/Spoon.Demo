namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Role;

using Create;
using DeletePermanent;
using DeleteSoft;
using Microsoft.AspNetCore.Routing;
using Spoon.NuGet.SecureRemotePassword.Endpoints.RoleClaim.AddBulk;
using Spoon.NuGet.SecureRemotePassword.Endpoints.RoleClaim.RemoveBulk;

/// <summary>
/// </summary>
public static class RoleEndpointExtensions
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapRoleEndpoints(this IEndpointRouteBuilder app)
    {
        //Create
        app.MapRoleCreate();
        
        //Delete
        app.MapRoleDeletePermanent();
        app.MapRoleDeleteSoft();
        
        return app;
    }
}