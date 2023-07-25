namespace Spoon.Demo.Application.V1.Administrator.CustomerTypes.Create.V1.Endpoint;

/// <summary>
///  Represents the response to create a CustomerType.
/// </summary>
public class CustomerTypeCreateEndpointV1Response
{
    /// <summary>
    ///  Gets or sets the CustomerType identifier.
    /// </summary>
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public Guid CustomerTypeId { get; init; }
}