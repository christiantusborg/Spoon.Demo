namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Me;

using ChangePassword;
using Delete;
using Email;
using Microsoft.AspNetCore.Routing;
using RecoveryCode;
using User;
using VerifyChallenge;

/// <summary>
/// </summary>
public static class MeEndpointExtensions
{
    /// <summary>
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapMeEndpoints(this IEndpointRouteBuilder app)
    {
        //ChangePassword
        app.MapMeChangePassword();

        //Delete
        app.MapMeDeleteSoft();

        //Email
        app.MapMeEmailCreate();
        app.MapMeEmailGet();
        app.MapMeEmailGetAll();
        app.MapMeEmailSetAsPrimary();
        app.MapMeEmailDelete();

        //RecoveryCode
        app.MapMeRecoveryCode();

        //VerifyChallenge
        app.MapMeVerifyChallengeGet();
        return app;
    }
}