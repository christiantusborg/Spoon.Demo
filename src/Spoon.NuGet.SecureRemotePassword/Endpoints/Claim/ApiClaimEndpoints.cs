namespace Spoon.NuGet.SecureRemotePassword.Endpoints.Claim;

/// <summary>
/// </summary>
public static class ApiClaimEndpoints
{
    public const string Tag = "Claim";
    private const string ApiBase = "api";
    public const string ContentType = "application/json";

    private const string Base = $"{ApiBase}/Claim";

        public static class GetAll
        {
            /// <inheritdoc cref="ApiClaimEndpoints" />
            public const string Name = $"{Base}GetAll";
            
            /// <inheritdoc cref="ApiClaimEndpoints" />
            public const string Endpoint = $"{Base}";

            /// <inheritdoc cref="ApiClaimEndpoints" />
            public const string Summary = "Get by ProductId";

            /// <inheritdoc cref="ApiClaimEndpoints" />
            public const string Description = "Get by ProductId";
        }         
}