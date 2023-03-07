namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Me;

/// <summary>
/// </summary>
public static class ApiMeEndpoints
{
    public const string Tag = "Me";
    private const string ApiBase = "api";
    public const string ContentType = "application/json";

    private const string Base = $"{ApiBase}/nls";

    public static class Email
    {
        /// <inheritdoc cref="ApiMeEndpoints" />
        public static class Create
        {
            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Endpoint = $"{Base}/Email";

            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Summary = "Add an email to current user.";

            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Description = "Add an email to current user.";
        }
        
        /// <inheritdoc cref="ApiMeEndpoints" />
        public static class Delete
        {
            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Endpoint = $"{Base}/Email/{{emailId:guid}}";

            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Summary = "Get by ProductId";

            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Description = "Get by ProductId";
        }   
        
        /// <inheritdoc cref="ApiMeEndpoints" />
        public static class SetAsPrimaryEmail
        {
            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Endpoint =  $"{Base}/Email/{{emailId:guid}}/SetAsPrimary";

            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Summary = "Get by ProductId";

            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Description = "Get by ProductId";
        
        }
        
        public static class Get
        {
            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Endpoint = $"{Base}/Email/{{emailId:guid}}";

            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Summary = "Get by ProductId";

            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Description = "Get by ProductId";
        }
        
        public static class GetAll
        {
            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Endpoint = $"{Base}/Email";

            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Summary = "Get by ProductId";

            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Description = "Get by ProductId";
        }         
    }
    
    /// <inheritdoc cref="ApiMeEndpoints" />
    public static class GetVerifyChallenge
    {
        /// <inheritdoc cref="ApiMeEndpoints" />
        public const string Endpoint = $"{Base}/GetVerifyChallenge" ;

        /// <inheritdoc cref="ApiMeEndpoints" />
        public const string Summary = "Get by ProductId";

        /// <inheritdoc cref="ApiMeEndpoints" />
        public const string Description = "Get by ProductId";
    }    

    /// <inheritdoc cref="ApiMeEndpoints" />
    public static class ChangePassword
    {
        /// <inheritdoc cref="ApiMeEndpoints" />
        public const string Endpoint = $"{Base}/ChangePassword";

        /// <inheritdoc cref="ApiMeEndpoints" />
        public const string Summary = "Change user password.";

        /// <inheritdoc cref="ApiMeEndpoints" />
        public const string Description = "Change user password.";
    }


    public static class Delete
    {
        /// <inheritdoc cref="ApiMeEndpoints" />
        public static class Soft
        {
            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Endpoint = $"{Base}/Email/{{emailId:guid}}/soft";

            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Summary = "Change user password.";

            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Description = "Change user password.";
        }
        
        /// <inheritdoc cref="ApiMeEndpoints" />
        public static class Permanent
        {
            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Endpoint = $"{Base}/Email/{{emailId:guid}}";

            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Summary = "Get by ProductId";

            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Description = "Get by ProductId";
        }        
    }
    

   


    /// <inheritdoc cref="ApiMeEndpoints" />
    public static class ConfirmEmail
    {
        /// <inheritdoc cref="ApiMeEndpoints" />
        public const string Endpoint = $"{Base}/ConfirmEmail";

        /// <inheritdoc cref="ApiMeEndpoints" />
        public const string Summary = "Get by ProductId";

        /// <inheritdoc cref="ApiMeEndpoints" />
        public const string Description = "Get by ProductId";
    }

    /// <inheritdoc cref="ApiMeEndpoints" />
    public static class RecoveryCode
    {
        /// <inheritdoc cref="ApiMeEndpoints" />
        public const string Endpoint = $"{Base}/RecoveryCode";

        /// <inheritdoc cref="ApiMeEndpoints" />
        public const string Summary = "Get by ProductId";

        /// <inheritdoc cref="ApiMeEndpoints" />
        public const string Description = "Get by ProductId";
    }




}