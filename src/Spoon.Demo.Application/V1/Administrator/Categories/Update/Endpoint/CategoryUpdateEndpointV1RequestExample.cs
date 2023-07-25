namespace Spoon.Demo.Application.V1.Administrator.Categories.Update.Endpoint;

/// <summary>
///  Represents the request to create a category.
/// </summary>
public sealed class CategoryUpdateEndpointV1RequestExample : IExamplesProvider<CategoryUpdateEndpointV1Request>
{
    /// <summary>
    ///  Gets the examples.
    /// </summary>
    /// <returns></returns>
    public CategoryUpdateEndpointV1Request GetExamples()
    {
        return new CategoryUpdateEndpointV1Request
        {
            Name = "Category name",
            Description = "Category description",
            Discount = 10,
            ProfitMargin = 10,
        };
    }
}