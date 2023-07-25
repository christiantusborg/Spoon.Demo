namespace Spoon.Demo.Application.V1.Administrator.Addresses.Get.V1.Endpoint;

/// <summary>
///  Represents the response to create a Address.
/// </summary>
public class AddressGetEndpointV1ResponseExample: IExamplesProvider<AddressGetEndpointV1Response>
{
    /// <summary>
    ///  Gets the examples.
    /// </summary>
    /// <returns></returns>
    public AddressGetEndpointV1Response GetExamples()
    {
        return new AddressGetEndpointV1Response
        {
            AddressId = EndpointExample.ExampleGuid,
        };
    }
}