namespace Spoon.Demo.Application.V1.Administrator.Categories.GetAll.V1.Endpoint;

/// <summary>
///  Represents the response to create a category.
/// </summary>
public class CategoryGetAllEndpointV1ResponseExample: IExamplesProvider<CategoryGetAllEndpointV1Response>
{
    /// <summary>
    ///  Gets the examples.
    /// </summary>
    /// <returns></returns>
    public CategoryGetAllEndpointV1Response GetExamples()
    {
        return new CategoryGetAllEndpointV1Response
        {
            CategoryId = EndpointExample.ExampleGuid,
        };
    }
}