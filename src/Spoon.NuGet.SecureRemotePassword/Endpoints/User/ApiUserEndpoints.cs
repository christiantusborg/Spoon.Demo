namespace Spoon.NuGet.SecureRemotePassword.Endpoints.User.Extensions;

/// <summary>
/// </summary>
public static class ApiUserEndpoints
{
    public const string Tag = "User";
    private const string ApiBase = "api";
    public const string ContentType = "application/json";

    private const string Base = $"{ApiBase}/Me";

    
    public static class Email
    {
        public const string EmailTag =  $"{Tag}/Email";
        
        /// <inheritdoc cref="ApiUserEndpoints" />
        public static class Confirm
        {
            /// <inheritdoc cref="ApiUserEndpoints" />
            public const string Name = $"{Base}EmailConfirm";        
        
            /// <inheritdoc cref="ApiUserEndpoints" />
            public const string Endpoint = $"{Base}/ConfirmEmail";

            /// <inheritdoc cref="ApiUserEndpoints" />
            public const string Summary = "Get by ProductId";

            /// <inheritdoc cref="ApiUserEndpoints" />
            public const string Description = "Get by ProductId";
        }
        
    }

    public static class ForgotPassword
    {
        public const string ForgotPasswordTag =  $"{Tag}/ForgotPasswordRecoverByEmail";
        
        /// <inheritdoc cref="ApiUserEndpoints" />
        public static class InitByEmail
        {
            /// <inheritdoc cref="ApiUserEndpoints" />
            public const string Name = $"{Base}ForgotPasswordRecoverByEmailInit";    
            
            /// <inheritdoc cref="ApiUserEndpoints" />
            public const string Endpoint = $"{Base}/ForgotPassword/Init";

            /// <inheritdoc cref="ApiUserEndpoints" />
            public const string Summary = "Get by ProductId";

            /// <inheritdoc cref="ApiUserEndpoints" />
            public const string Description = "Get by ProductId";        
        }

        /// <inheritdoc cref="ApiUserEndpoints" />
        public static class SetByEmail
        {
            /// <inheritdoc cref="ApiUserEndpoints" />
            public const string Name = $"{Base}ForgotPasswordSetByEmail"; 
            
            /// <inheritdoc cref="ApiUserEndpoints" />
            public const string Endpoint = $"{Base}/ForgotPassword";

            /// <inheritdoc cref="ApiUserEndpoints" />
            public const string Summary = "Get by ProductId";

            /// <inheritdoc cref="ApiUserEndpoints" />
            public const string Description = "Get by ProductId";        
        }    
        
    }
    
    /// <inheritdoc cref="ApiUserEndpoints" />
    public static class GetLoginChallenge
    {
        /// <inheritdoc cref="ApiUserEndpoints" />
        public const string Endpoint = $"{Base}/GetLoginChallenge" ;

        /// <inheritdoc cref="ApiUserEndpoints" />
        public const string Summary = "Get by ProductId";

        /// <inheritdoc cref="ApiUserEndpoints" />
        public const string Description = "Get by ProductId";
    }

    /// <inheritdoc cref="ApiUserEndpoints" />
    public static class SubmitLoginChallenge
    {
        /// <inheritdoc cref="ApiUserEndpoints" />
        public const string Endpoint = $"{Base}/SubmitChallenge";

        /// <inheritdoc cref="ApiUserEndpoints" />
        public const string Summary = "Get by ProductId";

        /// <inheritdoc cref="ApiUserEndpoints" />
        public const string Description = "Get by ProductId";
    }
   

    /// <inheritdoc cref="ApiUserEndpoints" />
    public static class Logout
    {
        /// <inheritdoc cref="ApiUserEndpoints" />
        public const string Name = $"{Base}Logout";
        
        /// <inheritdoc cref="ApiUserEndpoints" />
        public const string Endpoint = $"{Base}/Logout";

        /// <inheritdoc cref="ApiUserEndpoints" />
        public const string Summary = "Get by ProductId";

        /// <inheritdoc cref="ApiUserEndpoints" />
        public const string Description = "Get by ProductId";

        
    }

    /// <inheritdoc cref="ApiUserEndpoints" />
    public static class Refresh
    {
        /// <inheritdoc cref="ApiUserEndpoints" />
        public const string Endpoint = $"{Base}/Refresh";

        /// <inheritdoc cref="ApiUserEndpoints" />
        public const string Summary = "Get by ProductId";

        /// <inheritdoc cref="ApiUserEndpoints" />
        public const string Description = "Get by ProductId";
    }
  
    /// <inheritdoc cref="ApiUserEndpoints" />
    public static class Register
    {
        /// <inheritdoc cref="ApiUserEndpoints" />
        public const string Endpoint = $"{Base}/Register";

        /// <inheritdoc cref="ApiUserEndpoints" />
        public const string Summary = "Get by ProductId";

        /// <inheritdoc cref="ApiUserEndpoints" />
        public const string Description = "Get by ProductId";
    }    

    
    /// <inheritdoc cref="ApiUserEndpoints" />
    public static class ForgotPasswordRecoverByRecoveryCode
    {
        /// <inheritdoc cref="ApiUserEndpoints" />
        public const string Endpoint = $"{Base}/ForgotPasswordRecoverByRecoveryCode";

        /// <inheritdoc cref="ApiUserEndpoints" />
        public const string Summary = "Get by ProductId";

        /// <inheritdoc cref="ApiUserEndpoints" />
        public const string Description = "Get by ProductId";        
    }

}