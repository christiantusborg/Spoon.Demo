namespace Spoon.NuGet.SecureRemotePassword.Endpoints.User.Extensions;

using ForgotPassword;
using Me;
using Me.Email;
using Microsoft.AspNetCore.Routing;

/// <summary>
/// 
/// </summary>
public static class UserEndpointExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        
        //ConfirmEmail
        app.MapUserConfirmEmail();

        //ForgotPasswordByEmail
        app.MapUserForgotPasswordInitByEmail();
        app.MapUserForgotPasswordSetByEmail();
        
        //ForgotPasswordByEmail
        app.MapUserForgotPasswordByRecoveryCode();
        //app.MapMeRecoveryCode(); //Requrest Proff
        //app.MapUserGetLoginChallenge();
        //app.MapUserLogout();
        //app.MapUserRefresh();
        //app.MapUserRegister();
        //pp.MapMeEmailDelete(); //Requrest Proff

        //app.MapUserSubmitLoginChallenge();
        
        //app.MapCreateAuthentication();
        
        return app;
    }
}