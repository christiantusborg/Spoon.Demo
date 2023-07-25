namespace Spoon.Demo.Application.V1.Administrator.Addresses.Get.V1.Endpoint;

/// <summary>
///  Represents the response to create a Address.
/// </summary>
public class AddressGetEndpointV1Response
{
    /// <summary>
    ///  Gets or sets the Address identifier.
    /// </summary>
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public required Guid AddressId { get; init; }
}