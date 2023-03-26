namespace Spoon.NuGet.SecureRemotePassword.Endpoints;

using Administration;
using Claim;
using Me;
using Me.ChangePassword;
using Me.Delete;
using Me.Email;
using Me.RecoveryCode;
using Me.VerifyChallenge;
using Microsoft.AspNetCore.Routing;
using RoleClaim;
using User;
using UserClaim;
using UserRole;

public static class SecureRemotePasswordEndpointExtensions
{
    public static IEndpointRouteBuilder MapSecureRemotePasswordEndpoints(this IEndpointRouteBuilder app)
    {
        //AdministrationEndpoints
        app.MapAdministrationEndpoints();
            
        //MeEndpoints
        app.MapMeEndpoints();

;

        //RoleClaim
        app.MapRoleClaimEndpoints();
        
        //UserEndpoints
        app.MapUserEndpoints();
        app.MapUserRoleEndpoints();
        app.MapUserClaimEndpoints();
        
        //ClaimEndpoints
        app.MapClaimEndpoints();
        
        return app;
    }
}