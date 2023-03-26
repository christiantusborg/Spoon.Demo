namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Administration;

public static class ApiAdministrationEndpoints
{
    private const string ApiBase = "api";


    private const string Base = $"{ApiBase}/User/Administration";
 

    public static class SetUserEmailAsPrimary
    {
        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Endpoint = $"{Base}/SetAsPrimaryEmail/{{userId:guid}}";

        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Summary = "Set an email as primary email on a user.";

        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Description = "Allow an administrator to set an email as primary email on a user.";

        public static string Name =  $"{Base}SetUserEmailAsPrimary";
    }    

    public static class CreateUser
    {
        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Endpoint = $"{Base}/Create";

        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Summary = "Create new user.";

        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Description = "Allow an administrator to create a new user.";

        public static string Name =  $"{Base}CreateUser";
    }

    public static class DeleteUserSoft
    {
        public const string Endpoint = $"{Base}/{{userId:guid}}";
        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Summary = "Soft delete an user";

        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Description = "Allow an administrator to soft delete an user.";

        public static string Name =  $"{Base}DeleteUserSoft";
    }

    public static class DeleteUserPermanent
    {
        public const string Endpoint = $"{Base}/{{userId:guid}}/permanent";
        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Summary = "Permanent delete an user";

        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Description = "Allow an administrator to permanent delete an user.";

        public static string Name =  $"{Base}DeleteUserPermanent";
    }

    public static class GetAllUser
    {
        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Endpoint = Base;

        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Summary = "Get all users by search filters";

        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Description = "Get all users by search filters";

        public static string Name =  $"{Base}GetAllUser";
    }

    public static class Get
    {
        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Endpoint = $"{Base}/{{userId:guid}}";

        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Summary = "Get by userId";

        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Description = "Get by userId";
    }

    public static class SetUserFailedLockout
    {
        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Endpoint = $"{Base}/{{userId:guid}}/ToggleFailedLockout/{{value:bool}}";

        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Summary = "Set failed lockout for an userId.";

        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Description = "Set failed lockout for an userId.";

        public static string Name =  $"{Base}SetUserFailedLockout";
    }

    public static class SetUserMustChangePassword
    {
        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Endpoint = $"{Base}/{{userId:guid}}/ToggleChangePassword/{{value:bool}}";

        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Summary = "Set must change password for an user.";

        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Description = "Set must change password for an user.";

        public static string Name =  $"{Base}SetUserMustChangePassword";
    }

    public static class AddUserEmail
    {
        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Endpoint = $"{Base}/{{userId:guid}}/Add";

        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Summary = "Add an email to an userId";

        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Description = "Add an email to an userId";

        public static string Name =  $"{Base}AddUserEmail";
    }

    public static class RemoveUserEmail
    {
        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Endpoint = $"{Base}/{{userId:guid}}/RemoveEmail";

        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Summary = "Remove an email from an userId";

        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Description = "Remove an email from an userId";

        public static string Name =  $"{Base}RemoveUserEmail";
    }
    
    public static class SetUserPassword
    {
        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Endpoint = $"{Base}/{{userId:guid}}/setpssword";

        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Summary = "Get by ProductId";

        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Description = "Get by ProductId";

        public static string Name =  $"{Base}SetUserPassword";
    }

    public static class SetUserAllowedLogin
    {
        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Endpoint =  $"{Base}/{{userId:guid}}/ToggleAllowedLogin/{{value:bool}}";

        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Summary = "Set if an users is allowed to login";

        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Description = "Set if an users is allowed to login";

        public static string Name =  $"{Base}SetUserAllowedLogin";
    }

    public class GetUser
    {
        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Endpoint =  $"{Base}/{{userId:guid}}";

        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Summary = "Set if an users is allowed to login";

        /// <inheritdoc cref="ApiAdministrationEndpoints" />
        public const string Description = "Set if an users is allowed to login";

        public static string Name =  $"{Base}GetUser";        
    }
}