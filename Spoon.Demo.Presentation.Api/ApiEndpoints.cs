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
            public static readonly string[] PolicyGetAllPattern = new[] { "search", "page", "pageLength" };
            /// <inheritdoc cref="ApiEndpoints" />
            public static readonly string[] PolicyGetPattern = new[] { "productId" };
            /// <inheritdoc cref="ApiEndpoints" />
            public const string PolicyGet = "ProductCacheGet";
        }

        /// <inheritdoc cref="ApiEndpoints" />
        public static class SwaggerOperation
        {
            /// <inheritdoc cref="ApiEndpoints" />
            public const string CreateSummary = "Get by ProductId";
            /// <inheritdoc cref="ApiEndpoints" />
            public const string CreateDescription = "Get by ProductId";
            /// <inheritdoc cref="ApiEndpoints" />
            public const string DeletePermanentSummary = "Delete permanent by ProductId";
            /// <inheritdoc cref="ApiEndpoints" />
            public const string DeletePermanentDescription = "Delete permanent by ProductId";
            /// <inheritdoc cref="ApiEndpoints" />
            public const string DeleteSummary = "Delete by ProductId";
            /// <inheritdoc cref="ApiEndpoints" />
            public const string DeleteDescription = "Delete by ProductId";
            /// <inheritdoc cref="ApiEndpoints" />
            public const string UpdateSummary = "Update by ProductId";
            /// <inheritdoc cref="ApiEndpoints" />
            public const string UpdateDescription = "Update by ProductId";
            /// <inheritdoc cref="ApiEndpoints" />
            public const string GetSummary = "Get by ProductId";
            /// <inheritdoc cref="ApiEndpoints" />
            public const string GetDescription = "Get by ProductId";
            /// <inheritdoc cref="ApiEndpoints" />
            public const string GetAllSummary = "GetAll";
            /// <inheritdoc cref="ApiEndpoints" />
            public const string GetAllDescription = "GetAll";            
        }        
    }
}