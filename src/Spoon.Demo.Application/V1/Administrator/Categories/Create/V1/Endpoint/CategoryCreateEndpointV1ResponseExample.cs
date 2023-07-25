namespace Spoon.Demo.Application.V1.Administrator.Categories.Create.V1.Endpoint;

/// <summary>
///  Represents the response to create a category.
/// </summary>
public class CategoryCreateEndpointV1ResponseExample: IExamplesProvider<CategoryCreateEndpointV1Response>
{
    /// <summary>
    ///  Gets the examples.
    /// </summary>
    /// <returns></returns>
    public CategoryCreateEndpointV1Response GetExamples()
    {
        return new CategoryCreateEndpointV1Response
        {
            CategoryId = EndpointExample.ExampleGuid,
        };
    }
}