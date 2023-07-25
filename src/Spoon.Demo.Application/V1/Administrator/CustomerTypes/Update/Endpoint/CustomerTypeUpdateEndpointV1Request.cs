namespace Spoon.Demo.Application.V1.Administrator.CustomerTypes.Update.Endpoint;

/// <summary>
///    Represents the request to create a CustomerType.
/// </summary>
public class CustomerTypeUpdateEndpointV1Request 
{
    /// <inheritdoc cref="CustomerTypeUpdateEndpointV1Request" />
    public string? Name { get; init; }

    /// <inheritdoc cref="CustomerTypeUpdateEndpointV1Request" />
    public string? Description { get; init; }


}