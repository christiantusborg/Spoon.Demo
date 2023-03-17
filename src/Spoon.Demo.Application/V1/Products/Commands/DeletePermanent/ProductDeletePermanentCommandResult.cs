namespace Spoon.Demo.Application.V1.Products.Commands.DeletePermanent
{
    /// <summary>
    /// Class ProductDeletePermanentQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class ProductDeletePermanentCommandResult
    {
        /// <summary>
        /// Gets the product identifier.
        /// </summary>
        /// <value>The product identifier.</value>
        public Guid ProductId { get; internal set; }
    }
}