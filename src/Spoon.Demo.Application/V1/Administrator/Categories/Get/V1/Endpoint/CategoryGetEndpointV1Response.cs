namespace Spoon.Demo.Application.V1.Administrator.Categories.Get.V1.Endpoint;

/// <summary>
///  Represents the response to create a category.
/// </summary>
public class CategoryGetEndpointV1Response
{
    /// <summary>
    ///  Gets or sets the category identifier.
    /// </summary>
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public required Guid CategoryId { get; init; }
}