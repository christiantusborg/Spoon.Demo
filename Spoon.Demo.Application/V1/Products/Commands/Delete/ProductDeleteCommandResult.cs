namespace Spoon.Demo.Application.V1.Products.Commands.Delete
{
    /// <summary>
    /// Class ProductDeleteQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class ProductDeleteCommandResult
    {
        /// <summary>
        /// Gets the product identifier.
        /// </summary>
        /// <value>The product identifier.</value>
        public Guid ProductId { get; internal set; }
    }
}