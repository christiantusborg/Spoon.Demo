namespace Spoon.Demo.Application.V1.Products.Commands.UnDelete
{
    /// <summary>
    /// Class ProductDeleteQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class ProductUnDeleteCommandResult
    {
        /// <summary>
        /// Gets the product identifier.
        /// </summary>
        /// <value>The product identifier.</value>
        public Guid ProductId { get; internal set; }
    }
}