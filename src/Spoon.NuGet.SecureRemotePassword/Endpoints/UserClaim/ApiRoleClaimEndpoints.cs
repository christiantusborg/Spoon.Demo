namespace Spoon.NuGet.SecureRemotePassword.Endpoints.UserClaim;

/// <summary>
/// </summary>
public static class ApiUserClaimEndpoints
{
    public const string Tag = "UserClaim";
    private const string ApiBase = "api";
    public const string ContentType = "application/json";

    private const string Base = $"{ApiBase}/User";

        public static class AddBulk
        {
            /// <inheritdoc cref="ApiUserClaimEndpoints" />
            public const string Name = $"{Tag}AddBulk";
            
            /// <inheritdoc cref="ApiUserClaimEndpoints" />
            public const string Endpoint = $"{Base}/{{userId:Guid}}/Add/Claim";

            /// <inheritdoc cref="ApiUserClaimEndpoints" />
            public const string Summary = "Add claims to a role bulk.";

            /// <inheritdoc cref="ApiUserClaimEndpoints" />
            public const string Description = "Add claims to a role bulk.";
        }

        public static class RemoveBulk
        {
            /// <inheritdoc cref="ApiUserClaimEndpoints" />
            public const string Name = $"{Tag}AddBulk";

            /// <inheritdoc cref="ApiUserClaimEndpoints" />
            public const string Endpoint = $"{Base}/{{userId:Guid}}/Remove/Claim";

            /// <inheritdoc cref="ApiUserClaimEndpoints" />
            public const string Summary = "Remove claims from a role bulk.";

            /// <inheritdoc cref="ApiUserClaimEndpoints" />
            public const string Description = "Remove from to a role bulk.";
        }
}