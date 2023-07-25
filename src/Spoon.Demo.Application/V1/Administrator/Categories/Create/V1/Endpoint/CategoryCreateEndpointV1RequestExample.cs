namespace Spoon.Demo.Application.V1.Administrator.Categories.Create.V1.Endpoint;

/// <summary>
///  Represents the request to create a category.
/// </summary>
public sealed class CategoryCreateEndpointV1RequestExample : IExamplesProvider<CategoryCreateEndpointV1Request>
{
    /// <summary>
    ///  Gets the examples.
    /// </summary>
    /// <returns></returns>
    public CategoryCreateEndpointV1Request GetExamples()
    {
        return new CategoryCreateEndpointV1Request
        {
            Name = "Category name",
            Description = "Category description",
            Discount = 10,
            ProfitMargin = 10,
        };
    }
}