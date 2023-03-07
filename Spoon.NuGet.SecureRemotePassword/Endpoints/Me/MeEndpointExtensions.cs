namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Me;

using Email;
using Microsoft.AspNetCore.Routing;
using User;

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
        app.MapMeDeletePermanent();

        //Email
        app.MapMeEmailCreate();
        app.MapMeEmailGet();
        app.MapMeGetAllCreate();
        app.MapMeEmailSetAsPrimary();
        app.MapMeEmailDelete();

        //RecoveryCode
        app.MapMeRecoveryCode();

        return app;
    }
}