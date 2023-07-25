namespace Spoon.Demo.Application.V1.Administrator.CustomerTypes.Update.Endpoint;

/// <summary>
///  Represents the request to create a CustomerType.
/// </summary>
public sealed class CustomerTypeUpdateEndpointV1RequestExample : IExamplesProvider<CustomerTypeUpdateEndpointV1Request>
{
    /// <summary>
    ///  Gets the examples.
    /// </summary>
    /// <returns></returns>
    public CustomerTypeUpdateEndpointV1Request GetExamples()
    {
        return new CustomerTypeUpdateEndpointV1Request
        {
            Name = "CustomerType name",
            Description = "CustomerType description",
        };
    }
}