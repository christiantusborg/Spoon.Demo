namespace Spoon.Demo.Application.V1.Administrator.CustomerTypes.GetAll.V1.Endpoint;

/// <summary>
///  Represents the response to create a category.
/// </summary>
public class CustomerTypeGetAllEndpointV1ResponseExample: IExamplesProvider<CustomerTypeGetAllEndpointV1Response>
{
    /// <summary>
    ///  Gets the examples.
    /// </summary>
    /// <returns></returns>
    public CustomerTypeGetAllEndpointV1Response GetExamples()
    {
        return new CustomerTypeGetAllEndpointV1Response
        {
            CategoryId = EndpointExample.ExampleGuid,
        };
    }
}