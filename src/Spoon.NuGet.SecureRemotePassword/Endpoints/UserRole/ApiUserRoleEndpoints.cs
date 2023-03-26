namespace Spoon.NuGet.SecureRemotePassword.Endpoints.UserRole;

using RoleClaim;

/// <summary>
/// </summary>
public static class ApiUserRoleEndpoints
{
    public const string Tag = "RoleClaim";
    private const string ApiBase = "api";
    public const string ContentType = "application/json";

    private const string Base = $"{ApiBase}/User";

        public static class AddBulk
        {
            /// <inheritdoc cref="ApiRoleClaimEndpoints" />
            public const string Name = $"{Tag}AddBulk";
            
            /// <inheritdoc cref="ApiRoleClaimEndpoints" />
            public const string Endpoint = $"{Base}/{{userId:Guid}}/Add/Role";

            /// <inheritdoc cref="ApiRoleClaimEndpoints" />
            public const string Summary = "Add claims to a role bulk.";

            /// <inheritdoc cref="ApiRoleClaimEndpoints" />
            public const string Description = "Add claims to a role bulk.";
        }

        public static class RemoveBulk
        {
            /// <inheritdoc cref="ApiRoleClaimEndpoints" />
            public const string Name = $"{Tag}AddBulk";

            /// <inheritdoc cref="ApiRoleClaimEndpoints" />
            public const string Endpoint = $"{Base}/{{userId:Guid}}/Remove/Role";

            /// <inheritdoc cref="ApiRoleClaimEndpoints" />
            public const string Summary = "Remove claims from a role bulk.";

            /// <inheritdoc cref="ApiRoleClaimEndpoints" />
            public const string Description = "Remove from to a role bulk.";
        }
}