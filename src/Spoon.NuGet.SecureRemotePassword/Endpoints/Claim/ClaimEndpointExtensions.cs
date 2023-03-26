namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Claim;

using GetAll;
using Microsoft.AspNetCore.Routing;
using Spoon.NuGet.SecureRemotePassword.Endpoints.Me.ChangePassword;
using Spoon.NuGet.SecureRemotePassword.Endpoints.Me.Delete;
using Spoon.NuGet.SecureRemotePassword.Endpoints.Me.Email;
using Spoon.NuGet.SecureRemotePassword.Endpoints.Me.RecoveryCode;
using Spoon.NuGet.SecureRemotePassword.Endpoints.Me.VerifyChallenge;

/// <summary>
/// </summary>
public static class ClaimEndpointExtensions
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapClaimEndpoints(this IEndpointRouteBuilder app)
    {
        //GetALL
        app.MapClaimGetAll();
        
        return app;
    }
}