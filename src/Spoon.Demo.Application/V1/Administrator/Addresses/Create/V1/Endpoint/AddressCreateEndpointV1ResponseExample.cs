namespace Spoon.Demo.Application.V1.Administrator.Addresses.Create.V1.Endpoint;

/// <summary>
///  Represents the response to create a Address.
/// </summary>
public class AddressCreateEndpointV1ResponseExample: IExamplesProvider<AddressCreateEndpointV1Response>
{
    /// <summary>
    ///  Gets the examples.
    /// </summary>
    /// <returns></returns>
    public AddressCreateEndpointV1Response GetExamples()
    {
        return new AddressCreateEndpointV1Response
        {
            AddressId = EndpointExample.ExampleGuid,
        };
    }
}