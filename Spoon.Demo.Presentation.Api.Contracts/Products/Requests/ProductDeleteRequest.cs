namespace Spoon.Demo.Presentation.Api.Contracts.Products.Requests;

/// <summary>
///     Class ProductDeleteRequest.
/// </summary>
public class ProductDeleteRequest
{
    /// <summary>
    ///     Gets or sets the product identifier.
    /// </summary>
    /// <value>The product identifier.</value>
    public Guid ProductId { get; set; }
}