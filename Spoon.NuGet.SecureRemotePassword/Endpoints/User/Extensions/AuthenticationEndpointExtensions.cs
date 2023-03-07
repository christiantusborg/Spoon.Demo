namespace Spoon.NuGet.SecureRemotePassword.Endpoints.User.Extensions;

using Me;
using Me.Email;
using Microsoft.AspNetCore.Routing;

/// <summary>
/// 
/// </summary>
public static class AuthenticationEndpointExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapAuthenticationEndpoints(this IEndpointRouteBuilder app)
    {
        
        
        app.MapUserConfirmEmail();

        app.MapUserForgotPasswordRecoverByEmailInit();
        app.MapUserForgotPasswordRecoverByEmailSet();
        app.MapUserForgotPasswordRecoverByRecoveryCode();
        app.MapMeRecoveryCode(); //Requrest Proff
        app.MapUserGetLoginChallenge();
        app.MapUserLogout();
        app.MapUserRefresh();
        app.MapUserRegister();
        app.MapMeEmailDelete(); //Requrest Proff

        app.MapUserSubmitLoginChallenge();
        
        //app.MapCreateAuthentication();
        
        return app;
    }
}