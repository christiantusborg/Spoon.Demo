namespace Spoon.Demo.Application.V1.Administrator.CustomerTypes.Create.V1.Endpoint;

/// <summary>
///  Represents the request to create a category.
/// </summary>
public sealed class CustomerTypeCreateEndpointV1RequestExample : IExamplesProvider<CustomerTypeCreateEndpointV1Request>
{
    /// <summary>
    ///  Gets the examples.
    /// </summary>
    /// <returns></returns>
    public CustomerTypeCreateEndpointV1Request GetExamples()
    {
        return new CustomerTypeCreateEndpointV1Request
        {
            Name = "Category name",
            Description = "Category description",
        };
    }
}