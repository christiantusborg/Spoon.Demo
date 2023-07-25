namespace Spoon.Demo.Application.V1.Administrator.CustomerTypes.Get.V1.Endpoint;

/// <summary>
///  Represents the response to create a CustomerType.
/// </summary>
public class CustomerTypeGetEndpointV1ResponseExample: IExamplesProvider<CustomerTypeGetEndpointV1Response>
{
    /// <summary>
    ///  Gets the examples.
    /// </summary>
    /// <returns></returns>
    public CustomerTypeGetEndpointV1Response GetExamples()
    {
        return new CustomerTypeGetEndpointV1Response
        {
            CustomerTypeId = EndpointExample.ExampleGuid,

        };
    }
}