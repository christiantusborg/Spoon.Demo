namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Me;

/// <summary>
/// </summary>
public static class ApiMeEndpoints
{
    public const string Tag = "Me";
    private const string ApiBase = "api";
    public const string ContentType = "application/json";

    private const string Base = $"{ApiBase}/Me";

    public static class Email
    {
        public const string EmailTag =  $"{Tag}/Email";
        /// <inheritdoc cref="ApiMeEndpoints" />
        public static class Create
        {
            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Name = $"{Base}EmailCreate";
           
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
            public const string Name = $"{Base}EmailDelete";
            
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
            public const string Name = $"{Base}EmailSetAsPrimaryEmail";
            
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
            public const string Name = $"{Base}EmailGet";
            
            
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
            public const string Name = $"{Base}EmailGetAll";
            
            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Endpoint = $"{Base}/Email";

            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Summary = "Get by ProductId";

            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Description = "Get by ProductId";
        }         
    }
    
    /// <inheritdoc cref="ApiMeEndpoints" />
    public static class VerifyChallenge
    {
        public const string VerifyChallengeTag =  $"{Tag}/VerifyChallenge";
        public static class Get
        {
            public const string Name = $"{Base}GetVerifyChallenge";
        
            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Endpoint = $"{Base}/GetVerifyChallenge" ;

            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Summary = "Get by ProductId";

            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Description = "Get by ProductId";
            
        }
    }    

    /// <inheritdoc cref="ApiMeEndpoints" />
    public static class ChangePassword
    {
        
        public const string PasswordTag =  $"{Tag}/Password";
        
        public static class Create
        {
            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Name = $"{Base}ChangePasswordCreate";
            
            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Endpoint = $"{Base}/Password";

            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Summary = "Change user password.";

            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Description = "Change user password.";
        }
    }


    public static class Delete
    {
        /// <inheritdoc cref="ApiMeEndpoints" />
        public static class Soft
        {
            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Name = $"{Base}DeleteSoft";

            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Endpoint = $"{Base} ";

            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Summary = "Change user password.";

            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Description = "Change user password.";
        }
        
       
    }

    public static class RecoveryCode
    {
        public const string RecoveryCodeTag =  $"{Tag}/RecoveryCode";
        public static class Get
        {
            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Name = $"{Base}RecoveryCodeGet";
            
            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Endpoint = $"{Base}/RecoveryCode";

            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Summary = "Get by ProductId";

            /// <inheritdoc cref="ApiMeEndpoints" />
            public const string Description = "Get by ProductId";
        }
        
    }




}