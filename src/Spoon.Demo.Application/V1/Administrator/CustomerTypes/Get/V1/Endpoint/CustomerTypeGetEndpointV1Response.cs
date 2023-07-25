namespace Spoon.Demo.Application.V1.Administrator.CustomerTypes.Get.V1.Endpoint;

/// <summary>
///  Represents the response to create a CustomerType.
/// </summary>
public class CustomerTypeGetEndpointV1Response
{
    /// <summary>
    ///  Gets or sets the CustomerType identifier.
    /// </summary>
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public required Guid CustomerTypeId { get; init; }
}