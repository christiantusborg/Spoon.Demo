namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Administration;

using AddUserEmail;
using CreateUser;
using GetAllUser;
using GetUser;
using Microsoft.AspNetCore.Routing;
using RemoveUserEmail;
using SetUserMustChangePassword;
using Spoon.NuGet.SecureRemotePassword.Endpoints.User.ConfirmEmail;
using Spoon.NuGet.SecureRemotePassword.Endpoints.User.ForgotPassword;
using Spoon.NuGet.SecureRemotePassword.Endpoints.User.Login;
using Spoon.NuGet.SecureRemotePassword.Endpoints.User.Logout;
using Spoon.NuGet.SecureRemotePassword.Endpoints.User.Refresh;
using Spoon.NuGet.SecureRemotePassword.Endpoints.User.Register;

/// <summary>
/// 
/// </summary>
public static class AdministrationEndpointExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IEndpointRouteBuilder MapAdministrationEndpoints(this IEndpointRouteBuilder app)
    {

        //AddUserEmail
        app.MapAdministrationAddUserEmail();
        
        //CreateUser
        app.MapAdministrationCreateUser();
        
        //DeleteUser
        app.MapAdministrationCreateUser();
        
        //DeleteUserPermanent
        app.MapAdministrationSetUserPassword();
        
        //GetAllUser
        app.MapAdministrationGetAllUser();
        
        //GetUser
        app.MapAdministrationGetUser();
        
        //RemoveUserEmail
        app.MapAdministrationRemoveUserEmail();
        
        //SetUserAllowedLogin
        app.MapAdministrationSetUserAllowedLogin();
        
        //SetUserEmailAsPrimary
        app.MapAdministrationSetUserEmailAsPrimary();
        
        //SetUserFailedLockout
        app.MapAdministrationSetUserFailedLockout();
        
        //SetUserMustChangePassword
        app.MapAdministrationSetUserMustChangePassword();
        
        //SetUserPassword
        app.MapAdministrationSetUserPassword();
        
        return app;
    }
}