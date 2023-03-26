namespace Spoon.NuGet.SecureRemotePassword.Endpoints.User;

using ConfirmEmail;
using ForgotPassword;
using Login;
using Logout;
using Microsoft.AspNetCore.Routing;
using Refresh;
using Register;

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
        
        //Login
        app.MapUserLoginChallengeGet();
        app.MapUserSubmitLoginChallenge();
        
        //Logout
        app.MapUserLogout();
        app.MapUserLogoutAll();
        
        //Refresh
        app.MapUserRefresh();
        
        //Register
        app.MapUserRegister();
        
        return app;
    }
}