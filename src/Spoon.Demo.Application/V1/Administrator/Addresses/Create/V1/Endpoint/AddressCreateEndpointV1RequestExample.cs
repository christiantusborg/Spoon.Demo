namespace Spoon.Demo.Application.V1.Administrator.Addresses.Create.V1.Endpoint;

using Categories.Create.V1.Endpoint;

/// <summary>
///  Represents the request to create a Address.
/// </summary>
public sealed class AddressCreateEndpointV1RequestExample : IExamplesProvider<AddressCreateEndpointV1Request>
{
    /// <summary>
    ///  Gets the examples.
    /// </summary>
    /// <returns></returns>
    public AddressCreateEndpointV1Request GetExamples()
    {
        return new AddressCreateEndpointV1Request
        {
            CustomerId = EndpointExample.ExampleGuid,
            AddressOne = "AddressOne",
            AddressTwo = "AddressTwo",
            Zip = "Zip",
            City = "City",
            Country = "Country",
            AddressTypeId = 1
        };
    }
}