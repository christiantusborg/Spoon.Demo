namespace Spoon.Demo.Application.V1.Administrator.Addresses.Update.Endpoint;

/// <summary>
///  Represents the request to create a Address.
/// </summary>
public sealed class AddressUpdateEndpointV1RequestExample : IExamplesProvider<AddressUpdateEndpointV1Request>
{
    /// <summary>
    ///  Gets the examples.
    /// </summary>
    /// <returns></returns>
    public AddressUpdateEndpointV1Request GetExamples()
    {
        return new AddressUpdateEndpointV1Request
        {
            City = "Aalborg",
            Country = "Denmark",
            CustomerId = EndpointExample.ExampleGuid,
            Zip = "8000",
            AddressOne = "request.AddressOne",
            AddressTwo = "request.AddressTwo",
            AddressTypeId = 1,
        };
    }
}