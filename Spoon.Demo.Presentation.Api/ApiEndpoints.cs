namespace Spoon.Demo.Presentation.Api;

/// <summary>
/// 
/// </summary>
public static class ApiEndpoints
{
    private const string ApiBase = "api";

    /// <inheritdoc cref="ApiEndpoints" />
    public static class Products
    {
        private const string Base = $"{ApiBase}/products";

        /// <inheritdoc cref="ApiEndpoints" />
        public const string Create = Base;
        /// <inheritdoc cref="ApiEndpoints" />
        public const string Get = $"{Base}/{{productId:guid}}";
        /// <inheritdoc cref="ApiEndpoints" />
        public const string GetAll = Base;
        /// <inheritdoc cref="ApiEndpoints" />
        public const string Update = $"{Base}/{{productId:guid}}";
        /// <inheritdoc cref="ApiEndpoints" />
        public const string Delete = $"{Base}/{{productId:guid}}";
        /// <inheritdoc cref="ApiEndpoints" />
        public const string DeletePermanent = $"{Base}/{{productId:guid}}/permanent";

        /// <inheritdoc cref="ApiEndpoints" />
        public static class Cache
        {
            /// <inheritdoc cref="ApiEndpoints" />
            public const string EvictByTag = "ProductEvictByTag";
            /// <inheritdoc cref="ApiEndpoints" />
            public const string PolicyGetAll = "ProductCacheGetAll";
            /// <inheritdoc cref="ApiEndpoints" />
            public const string PolicyGet = "ProductCacheGet";
        }

    }
}