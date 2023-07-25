namespace Spoon.Demo.Application.V1.Administrator.Addresses.Update.Endpoint;

using Categories.Update.Endpoint;

/// <summary>
///    Represents the request to create a category.
/// </summary>
public class AddressUpdateEndpointV1Request 
{
    /// <inheritdoc cref="CategoryUpdateEndpointV1Request" />
    public Guid CustomerId { get; set; }
    /// <inheritdoc cref="CategoryUpdateEndpointV1Request" />
    public required string AddressOne { get; set; }
    /// <inheritdoc cref="CategoryUpdateEndpointV1Request" />
    public string? AddressTwo { get; set; }
    /// <inheritdoc cref="CategoryUpdateEndpointV1Request" />
    public required string Zip { get; set; }
    /// <inheritdoc cref="CategoryUpdateEndpointV1Request" />
    public required string City { get; set; }
    /// <inheritdoc cref="CategoryUpdateEndpointV1Request" />
    public required string Country { get; set; }
    /// <inheritdoc cref="CategoryUpdateEndpointV1Request" />
    public required int AddressTypeId { get; set; }
}