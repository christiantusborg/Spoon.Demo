namespace Spoon.Demo.Application.V1.Administrator.Categories.Get.V1.Endpoint;

/// <summary>
///  Represents the response to create a category.
/// </summary>
public class CategoryGetEndpointV1ResponseExample: IExamplesProvider<CategoryGetEndpointV1Response>
{
    /// <summary>
    ///  Gets the examples.
    /// </summary>
    /// <returns></returns>
    public CategoryGetEndpointV1Response GetExamples()
    {
        return new CategoryGetEndpointV1Response
        {
            CategoryId = EndpointExample.ExampleGuid,
        };
    }
}