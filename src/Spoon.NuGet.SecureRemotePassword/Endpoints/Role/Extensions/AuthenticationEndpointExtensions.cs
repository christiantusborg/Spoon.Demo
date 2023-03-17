namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Role.Extensions;

using Microsoft.AspNetCore.Routing;

/// <summary>
/// 
/// </summary>
public static class RoleEndpointExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapRoleEndpoints(this IEndpointRouteBuilder app)
    {
        //app.MapCreateAuthentication();
        
        return app;
    }
}