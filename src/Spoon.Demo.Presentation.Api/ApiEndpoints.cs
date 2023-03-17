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
        public static class Get
        {
            /// <inheritdoc cref="ApiEndpoints" />
            public const string Endpoint = $"{Base}/{{productId:guid}}";    
            

            /// <inheritdoc cref="ApiEndpoints" />
            public const string Summary = "Get by ProductId";

            /// <inheritdoc cref="ApiEndpoints" />
            public const string Description = "Get by ProductId";
            
            /// <inheritdoc cref="ApiEndpoints" />
            public const string Policy = "ProductCacheGet";
            
            /// <inheritdoc cref="ApiEndpoints" />
            public static readonly string[] PolicyPattern = new[] { "productId" };
        }
        
        /// <inheritdoc cref="ApiEndpoints" />
        public static class Create
        {
            /// <inheritdoc cref="ApiEndpoints" />
            public const string Endpoint = Base;    
            
            /// <inheritdoc cref="ApiEndpoints" />
            public const string Summary = "Create a new product.";

            /// <inheritdoc cref="ApiEndpoints" />
            public const string Description = "HERE WE SUPPORT HTML <strong>Create a new product.</strong>";
        }        
        
        /// <inheritdoc cref="ApiEndpoints" />
        public static class GetAll
        {
            /// <inheritdoc cref="ApiEndpoints" />
            public const string Endpoint = Base;    
            

            /// <inheritdoc cref="ApiEndpoints" />
            public const string Summary = "Create a new product.";

            /// <inheritdoc cref="ApiEndpoints" />
            public const string Description = "HERE WE SUPPORT HTML <strong>Create a new product.</strong>";
            
            /// <inheritdoc cref="ApiEndpoints" />
            public const string Policy = "ProductCacheGetAll";
            
            /// <inheritdoc cref="ApiEndpoints" />
            public static readonly string[] PolicyPattern = new[] { "search", "page", "pageLength" };
        }                
        
        /// <inheritdoc cref="ApiEndpoints" />
        public static class Update
        {
            /// <inheritdoc cref="ApiEndpoints" />
            public const string Endpoint = $"{Base}/{{productId:guid}}";
            
            /// <inheritdoc cref="ApiEndpoints" />
            public const string Summary = "Get by ProductId";

            /// <inheritdoc cref="ApiEndpoints" />
            public const string Description = "Get by ProductId";
        }        
        
        /// <inheritdoc cref="ApiEndpoints" />
        public static class Delete
        {
            /// <inheritdoc cref="ApiEndpoints" />
            public const string Endpoint = $"{Base}/{{productId:guid}}";
            
            /// <inheritdoc cref="ApiEndpoints" />
            public const string Summary = "Get by ProductId";

            /// <inheritdoc cref="ApiEndpoints" />
            public const string Description = "Get by ProductId";
        }        
        
        /// <inheritdoc cref="ApiEndpoints" />
        public static class DeletePermanent
        {
            /// <inheritdoc cref="ApiEndpoints" />
            public const string Endpoint =  $"{Base}/{{productId:guid}}/permanent";
            
            /// <inheritdoc cref="ApiEndpoints" />
            public const string Summary = "Get by ProductId";

            /// <inheritdoc cref="ApiEndpoints" />
            public const string Description = "Get by ProductId";
        }           

        /// <inheritdoc cref="ApiEndpoints" />
        public static class Cache
        {
            /// <inheritdoc cref="ApiEndpoints" />
            public const string EvictByTag = "ProductEvictByTag";

        }
    }
}