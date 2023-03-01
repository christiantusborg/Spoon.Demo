namespace Spoon.Demo.Application.V1.Products.Commands.Create
{
    /// <summary>
    /// Class ProductCreateQueryResult. This class cannot be inherited.
    /// </summary>
    public sealed class ProductCreateCommandResult
    {
        /// <summary>
        /// Gets the product identifier.
        /// </summary>
        /// <value>The product identifier.</value>
        public Guid ProductId { get; internal set; }
    }
}