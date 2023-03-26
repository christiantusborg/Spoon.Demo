namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Role;

/// <summary>
/// </summary>
public static class ApiRoleEndpoints
{
    public const string Tag = "Role";
    private const string ApiBase = "api";
    public const string ContentType = "application/json";

    private const string Base = $"{ApiBase}/Role";

        public static class Create
        {
            /// <inheritdoc cref="ApiRoleEndpoints" />
            public const string Name = $"{Tag}";
            
            /// <inheritdoc cref="ApiRoleEndpoints" />
            public const string Endpoint = $"{Base}";

            /// <inheritdoc cref="ApiRoleEndpoints" />
            public const string Summary = "Create role.";

            /// <inheritdoc cref="ApiRoleEndpoints" />
            public const string Description = "Create role.";
        }
        
        public static class DeletePermanent
        {
            /// <inheritdoc cref="ApiRoleEndpoints" />
            public const string Name = $"{Tag}";
            
            /// <inheritdoc cref="ApiRoleEndpoints" />
            public const string Endpoint = $"{Base}{{roleId}}/Permanent";

            /// <inheritdoc cref="ApiRoleEndpoints" />
            public const string Summary = "Delete permanent role.";

            /// <inheritdoc cref="ApiRoleEndpoints" />
            public const string Description = "Delete permanent role.";
        }    
        
        public static class DeleteSoft
        {
            /// <inheritdoc cref="ApiRoleEndpoints" />
            public const string Name = $"{Tag}";
            
            /// <inheritdoc cref="ApiRoleEndpoints" />
            public const string Endpoint = $"{Base}{{roleId}}/Soft";

            /// <inheritdoc cref="ApiRoleEndpoints" />
            public const string Summary = "Delete soft role.";

            /// <inheritdoc cref="ApiRoleEndpoints" />
            public const string Description = "Delete soft role.";
        }
        
        public static class Get
        {
            /// <inheritdoc cref="ApiRoleEndpoints" />
            public const string Name = $"{Tag}";
            
            /// <inheritdoc cref="ApiRoleEndpoints" />
            public const string Endpoint = $"{Base}{{roleId}}";

            /// <inheritdoc cref="ApiRoleEndpoints" />
            public const string Summary = "Get soft role.";

            /// <inheritdoc cref="ApiRoleEndpoints" />
            public const string Description = "Get soft role.";
        }        
}