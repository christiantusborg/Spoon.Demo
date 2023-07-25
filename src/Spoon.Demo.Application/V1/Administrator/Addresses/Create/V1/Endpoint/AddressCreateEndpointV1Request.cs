namespace Spoon.Demo.Application.V1.Administrator.Addresses.Create.V1.Endpoint;

/// <summary>
///    Represents the request to create a Address.
/// </summary>
public class AddressCreateEndpointV1Request 
{
    /// <inheritdoc cref="AddressCreateEndpointV1Request" />
    public Guid CustomerId { get; set; }
    /// <inheritdoc cref="AddressCreateEndpointV1Request" />
    public required string AddressOne { get; set; }
    /// <inheritdoc cref="AddressCreateEndpointV1Request" />
    public  string? AddressTwo { get; set; }
    /// <inheritdoc cref="AddressCreateEndpointV1Request" />
    public  required string Zip { get; set; }
    /// <inheritdoc cref="AddressCreateEndpointV1Request" />
    public required string City { get; set; }
    /// <inheritdoc cref="AddressCreateEndpointV1Request" />
    public required string Country { get; set; }
    /// <inheritdoc cref="AddressCreateEndpointV1Request" />
    public required int AddressTypeId { get; set; }
}