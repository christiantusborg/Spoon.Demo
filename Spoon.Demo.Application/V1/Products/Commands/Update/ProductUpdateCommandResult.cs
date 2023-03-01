namespace Spoon.Demo.Application.V1.Products.Commands.Update
{
    /// <summary>
    /// Class ProductUpdateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class ProductUpdateCommandResult
    {
        /// <summary>
        /// Gets the product identifier.
        /// </summary>
        /// <value>The product identifier.</value>
        public int ProductId { get; internal set; }
        
        /// <summary>
        /// </summary>
        public  string? Name  { get; internal set; } 
    }
}