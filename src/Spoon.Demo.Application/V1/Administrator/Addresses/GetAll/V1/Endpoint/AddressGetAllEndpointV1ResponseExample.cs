namespace Spoon.Demo.Application.V1.Administrator.Addresses.GetAll.V1.Endpoint;

/// <summary>
///  Represents the response to create a Address.
/// </summary>
public class AddressGetAllEndpointV1ResponseExample: IExamplesProvider<AddressGetAllEndpointV1Response>
{
    /// <summary>
    ///  Gets the examples.
    /// </summary>
    /// <returns></returns>
    public AddressGetAllEndpointV1Response GetExamples()
    {
        return new AddressGetAllEndpointV1Response
        {
            AddressId = EndpointExample.ExampleGuid,
        };
    }
}