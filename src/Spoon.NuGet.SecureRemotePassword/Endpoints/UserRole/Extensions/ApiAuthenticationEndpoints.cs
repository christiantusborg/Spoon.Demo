namespace Spoon.NuGet.SecureRemotePassword.Endpoints.UserRole.Extensions;

/// <summary>
/// </summary>
public static class ApiRoleUseEndpoints
{
    private const string ApiBase = "api";


    private const string Base = $"{ApiBase}/Role";

    /// <inheritdoc cref="ApiAuthenticationEndpoints" />
    public static class Get
    {
        /// <inheritdoc cref="ApiAuthenticationEndpoints" />
        public const string Endpoint = $"{Base}/GetChallenge" ;

        /// <inheritdoc cref="ApiAuthenticationEndpoints" />
        public const string Summary = "Get by ProductId";

        /// <inheritdoc cref="ApiAuthenticationEndpoints" />
        public const string Description = "Get by ProductId";
    }

    /// <inheritdoc cref="ApiAuthenticationEndpoints" />
    public static class GetAll
    {
        /// <inheritdoc cref="ApiAuthenticationEndpoints" />
        public const string Endpoint = $"{Base}/GetChallenge" ;

        /// <inheritdoc cref="ApiAuthenticationEndpoints" />
        public const string Summary = "Get by ProductId";

        /// <inheritdoc cref="ApiAuthenticationEndpoints" />
        public const string Description = "Get by ProductId";
    }    
    
    /// <inheritdoc cref="ApiAuthenticationEndpoints" />
    public static class AddUser
    {
        /// <inheritdoc cref="ApiAuthenticationEndpoints" />
        public const string Endpoint = $"{Base}/GetChallenge" ;

        /// <inheritdoc cref="ApiAuthenticationEndpoints" />
        public const string Summary = "Get by ProductId";

        /// <inheritdoc cref="ApiAuthenticationEndpoints" />
        public const string Description = "Get by ProductId";
    }    
    
    /// <inheritdoc cref="ApiAuthenticationEndpoints" />
    public static class RemoveUser
    {
        /// <inheritdoc cref="ApiAuthenticationEndpoints" />
        public const string Endpoint = $"{Base}/GetChallenge" ;

        /// <inheritdoc cref="ApiAuthenticationEndpoints" />
        public const string Summary = "Get by ProductId";

        /// <inheritdoc cref="ApiAuthenticationEndpoints" />
        public const string Description = "Get by ProductId";
    }    
}